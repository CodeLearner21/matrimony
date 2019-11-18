using Matrimony.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses.Repositories
{
    public class GetFilesResponse : BaseGatewayResponse
    {
        public IEnumerable<PortfolioFile> Files { get; set; }

        public GetFilesResponse(IEnumerable<PortfolioFile> files, bool success = false, IEnumerable<ResponseError> errors = null) : base(success, errors)
        {
            Files = files;
        }
    }
}
