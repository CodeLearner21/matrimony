using Autofac;
using Matrimony.WebAPI.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrimony.WebAPI
{
    public class APIPresenterModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<RegisterUserPresenter>().SingleInstance();
            builder.RegisterType<LoginPresenter>().SingleInstance();
            builder.RegisterType<PasswordResetPresenter>().SingleInstance();
            builder.RegisterType<CreatePortfolioPresenter>().SingleInstance();
            builder.RegisterType<PortfolioTypeListPresenter>().SingleInstance();
            builder.RegisterType<CurrentUserPresenter>().SingleInstance();
        }
    }
}
