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
                .ConstructUsing(u => new AppUser 
                { 
                    Id = u.Id, 
                    FirstName = u.FirstName, 
                    LastName = u.LastName, 
                    UserName = u.UserName,
                    PasswordHash = u.Password
                });
            
            CreateMap<AppUser, User>()
                .ConstructUsing(au => new User(
                    au.FirstName, 
                    au.LastName, 
                    au.Email, 
                    au.UserName, 
                    au.Id,
                    au.PasswordHash));

            CreateMap<PortfolioType, PortfolioTypeDomain>()
                .ConstructUsing(pt => new PortfolioTypeDomain(
                    pt.Name, 
                    pt.Id));

            CreateMap<PortfolioFile, PortfolioDocument>()
                .ConvertUsing(pf => new PortfolioDocument
                {
                    Id = new Guid(),
                    Type = pf.Type,
                    Title = pf.Title,
                    Name = pf.Name,
                    DirectoryName = pf.DirectoryName,
                    DateCreated = pf.DateCreated,
                    PortfolioId = Guid.Parse(pf.PortfolioId)
                });

            CreateMap<PortfolioDocument, PortfolioFile>()
                .ConstructUsing(pd => new PortfolioFile(
                    pd.Type,
                    pd.Title,
                    pd.Name,
                    pd.DirectoryName,
                    pd.DateCreated, 
                    pd.PortfolioId.ToString(), 
                    pd.Id.ToString()));

            CreateMap<UserPortfolio, Portfolio>()
                .ConstructUsing(up => new Portfolio
                {
                    Id = Guid.NewGuid(),
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
                    p.Id.ToString()));

        }
    }
}
