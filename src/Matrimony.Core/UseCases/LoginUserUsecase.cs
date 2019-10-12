using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos;
using Matrimony.Core.Dtos.UseCaseRequests;
using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Core.Interfaces.Services;
using Matrimony.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.UseCases
{
    public class LoginUserUsecase : ILoginUserUsecase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public LoginUserUsecase(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<bool> Handle(LoginRequest request, IOutputPort<LoginResponse> outputPort)
        {
            if(!string.IsNullOrEmpty(request.Email) && !string.IsNullOrEmpty(request.Password))
            {
                // confirm we have a user with the given name
                var user = await _userRepository.FindByEmail(request.Email);
                if (user != null)
                {
                    // validate password
                    if (await _userRepository.CheckPassword(user, request.Password))
                    {
                        // generate token
                        outputPort.Handle(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName), true));
                        return true;
                    }
                }
            }

            outputPort.Handle(new LoginResponse(new[] { new Error("login_failure", "Invalid username or password.") }));
            return false;
        }
    }
}
