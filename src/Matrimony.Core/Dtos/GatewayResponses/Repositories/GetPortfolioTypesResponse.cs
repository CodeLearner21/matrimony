using Matrimony.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses.Repositories
{
    public class GetPortfolioTypesResponse : BaseGatewayResponse
    {
        public IEnumerable<PortfolioTypeDomain> PortfolioTypes { get; set; }
        public GetPortfolioTypesResponse(IEnumerable<PortfolioTypeDomain> portfolioTypes, bool success = false, IEnumerable<ResponseError> errors = null) : base(success, errors)
        {
            PortfolioTypes = portfolioTypes;
        }
    }
}
