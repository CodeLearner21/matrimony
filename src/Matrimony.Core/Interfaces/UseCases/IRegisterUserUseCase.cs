using Matrimony.Core.Dtos.UseCaseRequests;
using Matrimony.Core.Dtos.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.Interfaces.UseCases
{
    public interface IRegisterUserUseCase
    {
        Task<bool> Handle(RegisterUserRequest request, IOutputPort<RegisterUserResponse> outputPort);
    }
}
