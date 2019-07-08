using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseRequests
{
    public class PasswordResetRequest : IUseCaseRequest<PasswordResetResponse>
    {
        public string Email { get; }

        public PasswordResetRequest(string email)
        {
            Email = email;
        }
    }
}
