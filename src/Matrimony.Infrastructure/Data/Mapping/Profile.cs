using AutoMapper;
using Matrimony.Core.Domain.Entities;
using Matrimony.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>()
                .ConstructUsing(u => new AppUser { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName, PasswordHash = u.PasswordHash });
            CreateMap<AppUser, User>()
                .ConstructUsing(au => new User(au.FirstName, au.LastName, au.Email, au.UserName, au.Id, au.PasswordHash));

            CreateMap<UserPortfolio, Portfolio>()
                .ConstructUsing(up => new Portfolio
                {
                    Id = up.Id,
                    ProfileName = up.ProfileName,
                    Gender = up.Gender,
                    BirthDate = up.BirthDate,
                    AppUserId = up.UserId,
                    PortfolioTypeId = up.PortfolioTypeId
                });

            CreateMap<Portfolio, UserPortfolio>()
                .ConstructUsing(p => new UserPortfolio(
                    p.ProfileName,
                    p.Gender,
                    p.BirthDate,
                    p.AppUserId, 
                    p.PortfolioTypeId,
                    p.Id ));

        }
    }
}
