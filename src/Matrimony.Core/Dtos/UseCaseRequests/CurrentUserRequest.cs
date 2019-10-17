using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseRequests
{
    public class CurrentUserRequest : IUseCaseRequest<CurrentUserResponse>
    {
        public string UserName { get; }

        public CurrentUserRequest(string userName)
        {
            UserName = userName;
        }
    }
}
