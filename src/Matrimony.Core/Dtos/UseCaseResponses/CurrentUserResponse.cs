using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class CurrentUserResponse : UseCaseResponseMessage
    {
        public User User { get; set; }

        public IEnumerable<Error> Errors { get; }

        public CurrentUserResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public CurrentUserResponse(User user, bool success = false, string message = null) : base(success, message)
        {
            User = user;
        }
    }
}
