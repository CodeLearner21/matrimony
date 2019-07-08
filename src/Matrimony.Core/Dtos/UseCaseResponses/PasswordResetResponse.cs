using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class PasswordResetResponse : UseCaseResponseMessage
    {
        public string SuccessMessage { get; set; }
        public IEnumerable<Error> Errors { get; }

        public PasswordResetResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public PasswordResetResponse(string successMsg,bool success = false, string message = null) : base(success, message)
        {
            SuccessMessage = successMsg;
        }
    }
}
