using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.UseCaseRequests;
using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.UseCases
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest request, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(request.FirstName, request.LastName, request.Email), request.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, response.UserName, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));

            return response.Success;
        }
    }
}
