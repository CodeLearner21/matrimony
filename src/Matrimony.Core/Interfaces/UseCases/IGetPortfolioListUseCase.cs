using Matrimony.Core.Dtos.UseCaseResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.Interfaces.UseCases
{
    public interface IGetPortfolioListUseCase
    {
        Task<bool> Handle(IOutputPort<GetAllPortfolioTypesResponse> outputPort);
    }
}
