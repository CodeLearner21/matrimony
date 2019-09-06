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
    public class GetPortfolioListUseCase : IGetPortfolioListUseCase
    {
        private readonly IPortfolioTypeRepository _portfolioTypeRepository;

        public GetPortfolioListUseCase(IPortfolioTypeRepository portfolioTypeRepository)
        {
            _portfolioTypeRepository = portfolioTypeRepository;
        }

        public async Task<bool> Handle(IOutputPort<GetAllPortfolioTypesResponse> outputPort)
        {
            var response = await _portfolioTypeRepository.GetAll();
            outputPort.Handle(response.Success ? new GetAllPortfolioTypesResponse(response.PortfolioTypes, true) : new GetAllPortfolioTypesResponse(response.Errors.Select(e => e.Description)));

            return response.Success;
        }
    }
}
