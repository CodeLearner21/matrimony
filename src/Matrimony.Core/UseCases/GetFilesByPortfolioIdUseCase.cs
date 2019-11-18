using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Core.Interfaces.UseCases;
using System.Linq;
using System.Threading.Tasks;

namespace Matrimony.Core.UseCases
{
    public class GetFilesByPortfolioIdUseCase : IGetFilesByPortfolioIdUseCase
    {
        private readonly IPortfolioRepository _portfolioRepository;
        public GetFilesByPortfolioIdUseCase(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<bool> Handle(string portfolioId, IOutputPort<GetFilesByPortfolioIdResponse> outputPort)
        {
            var response = await _portfolioRepository.GetFilesById(portfolioId);
            outputPort.Handle(response.Success ? new GetFilesByPortfolioIdResponse(response.Files, true) : new GetFilesByPortfolioIdResponse(response.Errors.Select(e => e.Description)));

            return response.Success;
        }
    }
}
