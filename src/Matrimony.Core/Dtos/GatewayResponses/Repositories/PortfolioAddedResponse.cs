using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses.Repositories
{
    public class PortfolioAddedResponse : BaseGatewayResponse
    {
        public string Id { get; set; }
        public PortfolioAddedResponse(string id, bool success = false, IEnumerable<ResponseError> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
