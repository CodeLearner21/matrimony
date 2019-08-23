using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses.Repositories
{
    public class PortfolioAddedResponse : BaseGatewayResponse
    {
        public int Id { get; set; }
        public PortfolioAddedResponse(int id, bool success = false, IEnumerable<ResponseError> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
