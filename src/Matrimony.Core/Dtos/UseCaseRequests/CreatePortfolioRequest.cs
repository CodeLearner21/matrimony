using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseRequests
{
    public class CreatePortfolioRequest : IUseCaseRequest<CreatePortfolioResponse>
    {
        public string ProfileName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserId { get; set; }
        public int PortfolioTypeId { get; set; }

        public CreatePortfolioRequest(string profileName, string gender, DateTime birthDate, string userId, int portfolioTypeId)
        {
            ProfileName = profileName;
            Gender = gender;
            BirthDate = birthDate;
            UserId = userId;
            PortfolioTypeId = portfolioTypeId;
        }
    }
}
