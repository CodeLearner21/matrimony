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
    public class CreatePortfolioUseCase : ICreatePortfolioUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;
        public CreatePortfolioUseCase(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }
        public async Task<bool> Handle(CreatePortfolioRequest request, IOutputPort<CreatePortfolioResponse> outputPort)
        {
            var response = await _portfolioRepository.Create(new UserPortfolio(request.ProfileName, request.UserId, request.PortfolioTypeId, request.SubCasteId));
            outputPort.Handle(response.Success ? new CreatePortfolioResponse(response.Id, true) : new CreatePortfolioResponse(response.Errors.Select(e => e.Description)));

            return response.Success;
        }
    }
}
