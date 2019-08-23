using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class RegisterUserResponse : UseCaseResponseMessage
    {
        public string Id { get; }
        public string UserName { get; set; }
        public IEnumerable<string> Errors { get; }

        public RegisterUserResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public RegisterUserResponse(string id, string userName, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
            UserName = userName;
        }
    }
}
