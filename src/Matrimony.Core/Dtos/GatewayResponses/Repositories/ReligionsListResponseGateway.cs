using Matrimony.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses.Repositories
{
    public class ReligionsListResponseGateway : BaseGatewayResponse
    {
        public IEnumerable<ReligionEntity> Religions { get; set; }
        public ReligionsListResponseGateway(IEnumerable<ReligionEntity> religions, bool success = false, IEnumerable<ResponseError> errors = null) : base(success, errors)
        {
            Religions = religions;
        }
    }
}
