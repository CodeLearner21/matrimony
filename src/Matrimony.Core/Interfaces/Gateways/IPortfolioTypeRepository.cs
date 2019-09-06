using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.Interfaces.Gateways
{
    public interface IPortfolioTypeRepository
    {
        Task<GetPortfolioTypesResponse> GetAll();
    }
}
