using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses
{
    public class ResponseError
    {
        public string Code { get; }
        public string Description { get; }

        public ResponseError(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
