using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Domain.Entities
{
    public class UserPortfolio
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public string UserId { get; set; }
        public int PortfolioTypeId { get; set; }

        public UserPortfolio(string profileName,
            string userId, 
            int portfolioTypeId, 
            int id = 0)
        {
            Id = id;
            ProfileName = profileName;
            UserId = userId;
            PortfolioTypeId = portfolioTypeId;
        }
    }
}
