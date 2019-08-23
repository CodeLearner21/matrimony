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
                    AppUserId = up.UserId,
                    PortfolioTypeId = up.PortfolioTypeId,
                    SubCasteId = up.SubCasteId
                });

            CreateMap<Portfolio, UserPortfolio>()
                .ConstructUsing(p => new UserPortfolio(
                    p.ProfileName,
                    p.AppUserId, 
                    p.PortfolioTypeId, 
                    p.SubCasteId, 
                    p.Id ));

            CreateMap<SubCasteEntity, SubCaste>();
            CreateMap<SubCaste, SubCasteEntity>();

            CreateMap<CasteEntity, Caste>()
                .ForMember(m => m.SubCastes, opt => opt.MapFrom(s => s.SubCastes));

            CreateMap<Caste, CasteEntity>()
                .ForMember(m => m.SubCastes, opt => opt.MapFrom(s => s.SubCastes));

            CreateMap<ReligionEntity, Religion>()
                .ForMember(m => m.Communities, opt => opt.MapFrom(s => s.Communities));

            CreateMap<Religion, ReligionEntity>()
                .ForMember(m => m.Communities, opt => opt.MapFrom(s => s.Communities));

            CreateMap<CommunityEntity, Community>()
                .ForMember(m => m.Castes, opt => opt.MapFrom(s => s.Castes));

            CreateMap<Community, CommunityEntity>()
                .ForMember(m => m.Castes, opt => opt.MapFrom(s => s.Castes));

            CreateMap<ReligionEntity, Religion>()
                .ForMember(m => m.Communities, opt => opt.MapFrom(s => s.Communities));

            CreateMap<Religion, ReligionEntity>()
                .ForMember(m => m.Communities, opt => opt.MapFrom(s => s.Communities)); 

        }
    }
}
