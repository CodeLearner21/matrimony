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
    public class GetUserPortfolioUseCase : IGetUserPortfolioUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;
        public GetUserPortfolioUseCase(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<bool> Handle(string userId, IOutputPort<UserPortfolioResponse> outputPort)
        {
            var response = await _portfolioRepository.GetByUserId(userId);
            outputPort.Handle(response.Success ? new UserPortfolioResponse(response.UserPortfolio, true) : new UserPortfolioResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
