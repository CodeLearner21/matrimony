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
        public string UserId { get; set; }
        public int PortfolioTypeId { get; set; }
        public int SubCasteId { get; set; }

        public CreatePortfolioRequest(string profileName, string userId, int portfolioTypeId, int subCasteId)
        {
            ProfileName = profileName;
            UserId = userId;
            PortfolioTypeId = portfolioTypeId;
            SubCasteId = subCasteId;
        }
    }
}
