using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Matrimony.Core;
using Matrimony.Core.Interfaces.UseCases;
using Matrimony.Infrastructure;
using Matrimony.Infrastructure.Auth;
using Matrimony.Infrastructure.Data.Entities;
using Matrimony.Infrastructure.Data.EntityFramework;
using Matrimony.Infrastructure.Email;
using Matrimony.Infrastructure.Extensions;
using Matrimony.WebAPI.Extensions;
using Matrimony.WebAPI.Presenters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Matrimony.WebAPI
{
    public class Startup
    {

        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Matrimony.Infrastructure")));

            
            // Configure Email settings
            services.Configure<EmailConfig>(Configuration.GetSection(nameof(EmailConfig)));
            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                b =>
                {
                    b.WithOrigins("http://localhost:4200");
                    b.AllowAnyMethod();
                    b.AllowAnyHeader();
                });
            });
            // jwt wire up
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // add identity
            var identityBuilder = services.AddIdentityCore<AppUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole), identityBuilder.Services);
            identityBuilder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            // Add MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Automapper
            //services.AddAutoMapper(typeof(Startup));

            // Add Swagger
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Info { Title = "Matrimony Web API", Version = "v1" });
            });


            // Autofac
            var builder = new ContainerBuilder();

            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new MappingProfileModule());

            // Presenters
            builder.RegisterType<RegisterUserPresenter>().SingleInstance();
            builder.RegisterType<LoginPresenter>().SingleInstance();
            builder.RegisterType<PasswordResetPresenter>().SingleInstance();
            builder.RegisterType<CreatePortfolioPresenter>().SingleInstance();
            builder.RegisterType<ReligionsListPresenter>().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).SingleInstance();
            

            builder.Populate(services);
            var container = builder.Build();
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                context.Response.AddApplicationError(error.Error.Message);
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
                });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanAspNetCoreWebAPI V1");
            });

            // Update Database
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<ApplicationDbContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<ApplicationDbContext>().EnsureSeeded();
                }

            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.            
            app.UseAuthentication();
            app.UseSwagger();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();            
            app.UseMvc();
        }
    }
}
