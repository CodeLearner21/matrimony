using Autofac;
using Matrimony.Core.Interfaces.UseCases;
using Matrimony.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core
{
    public class CoreModule : Module
    {
        public CoreModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUserUsecase>().As<ILoginUserUsecase>().InstancePerLifetimeScope();
            builder.RegisterType<ResetPasswordUseCase>().As<IResetPasswordUseCase>().InstancePerLifetimeScope();
        }
    }
}
