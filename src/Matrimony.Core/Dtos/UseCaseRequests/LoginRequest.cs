using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseRequests
{
    public class LoginRequest : IUseCaseRequest<LoginResponse>
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
