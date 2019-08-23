using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.Interfaces.Gateways
{
    public interface IReligionRepository
    {
        Task<ReligionsListResponseGateway> GetAll();
    }
}
