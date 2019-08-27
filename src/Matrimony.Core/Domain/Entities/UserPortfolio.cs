using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Domain.Entities
{
    public class UserPortfolio
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserId { get; set; }
        public int PortfolioTypeId { get; set; }

        public UserPortfolio(string profileName,             
            string gender,
            DateTime birthDate,
            string userId,
            int portfolioTypeId, 
            int id = 0)
        {
            Id = id;
            ProfileName = profileName;
            Gender = gender;
            BirthDate = birthDate;
            UserId = userId;
            PortfolioTypeId = portfolioTypeId;
        }
    }
}
