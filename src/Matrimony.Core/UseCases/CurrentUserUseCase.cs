using Matrimony.Core.Dtos;
using Matrimony.Core.Dtos.UseCaseRequests;
using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.UseCases
{
    public class CurrentUserUseCase : ICurrentUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public CurrentUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CurrentUserRequest request, IOutputPort<CurrentUserResponse> outputPort)
        {
            if (!string.IsNullOrWhiteSpace(request.UserName))
            {
                var user = await _userRepository.FindByName(request.UserName);
                if(user != null)
                {
                    outputPort.Handle(new CurrentUserResponse(user, true, null));
                    return true;
                }
            }

            outputPort.Handle(new CurrentUserResponse(new[] { new Error("Error Occur", "No user found") }));
            return false;
        }
    }
}
