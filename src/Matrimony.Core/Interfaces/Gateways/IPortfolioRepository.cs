using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.Interfaces.Gateways
{
    public interface IPortfolioRepository
    {
        Task<PortfolioAddedResponse> Create(UserPortfolio userPortfolio);
        Task<FileCreatedResponse> AddFile(PortfolioFile userFile);
        Task<UserPortfolio> FindByUserName(string userName);
        Task<GetPortfolioByUserIdResponse> GetByUserId(string userId);
        Task<GetFilesResponse> GetFilesById(string portfolioId);
    }
}
