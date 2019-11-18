using Matrimony.Core.Dtos.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.Interfaces.UseCases
{
    public interface IGetUserPortfolioUseCase
    {
        Task<bool> Handle(string userId, IOutputPort<UserPortfolioResponse> outputPort);
    }
}
