using Autofac;
using AutoMapper;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Core.Interfaces.Services;
using Matrimony.Infrastructure.Auth;
using Matrimony.Infrastructure.Data.EntityFramework.Repositories;
using Matrimony.Infrastructure.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Matrimony.Infrastructure
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();            
            builder.RegisterType<DataProfile>().As<Profile>();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
