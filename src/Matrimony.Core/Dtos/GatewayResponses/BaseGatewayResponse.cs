using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.GatewayResponses
{
    public abstract class BaseGatewayResponse
    {
        public bool Success { get; }
        public IEnumerable<ResponseError> Errors { get; }

        protected BaseGatewayResponse(bool success = false, IEnumerable<ResponseError> errors = null)
        {
            Success = success;
            Errors = errors;
        }
    }
}
