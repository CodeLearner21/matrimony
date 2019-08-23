using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses.Repositories
{
    public class CreateUserResponse : BaseGatewayResponse
    {
        public string Id { get; }
        public string UserName { get; set; }
        public CreateUserResponse(string id, string userName, bool success = false, IEnumerable<ResponseError> errors = null) : base(success, errors)
        {
            Id = id;
            UserName = userName;
        }
    }
}
