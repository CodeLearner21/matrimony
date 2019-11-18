using Matrimony.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses.Repositories
{
    public class GetPortfolioByUserIdResponse : BaseGatewayResponse
    {
        public UserPortfolio UserPortfolio { get; set; }

        public GetPortfolioByUserIdResponse(UserPortfolio userPortfolio, bool success = false, IEnumerable<ResponseError> errors = null) : base(success, errors)
        {
            UserPortfolio = userPortfolio;
        }
    }
}
