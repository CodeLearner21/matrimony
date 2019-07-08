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
    public class ResetPasswordUseCase : IResetPasswordUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public ResetPasswordUseCase(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<bool> Handle(PasswordResetRequest request, IOutputPort<PasswordResetResponse> outputPort)
        {
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                // confirm we have a user with the given name
                var user = await _userRepository.FindByEmail(request.Email);

                if (user != null)
                {
                    // Send password link through email
                    await _emailService.SendEmailAsync();

                    outputPort.Handle(new PasswordResetResponse("Please check your inbox for reset password link", true));
                    return true;
                }
            }

            outputPort.Handle(new PasswordResetResponse(new[] { new Error("password_reset_failure", "Email address not found in our database.") }));
            return false;
        }

    }
}
