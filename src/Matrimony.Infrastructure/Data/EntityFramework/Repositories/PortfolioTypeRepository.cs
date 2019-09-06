using AutoMapper;
using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.GatewayResponses;
using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using Matrimony.Core.Interfaces.Gateways;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Infrastructure.Data.EntityFramework.Repositories
{
    public class PortfolioTypeRepository : IPortfolioTypeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PortfolioTypeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetPortfolioTypesResponse> GetAll()
        {
            List<ResponseError> responseErrors = new List<ResponseError>();

            try
            {
                var portfolioTypes = await _context.PortfolioTypes.ToListAsync();
                if (portfolioTypes == null)
                {
                    responseErrors.Add(new ResponseError("404", "Portfolio types not found"));
                    return new GetPortfolioTypesResponse(null, false, responseErrors);
                }                    
                var portfolioTypesDto = _mapper.Map<IEnumerable<PortfolioTypeDomain>>(portfolioTypes);
                return new GetPortfolioTypesResponse(portfolioTypesDto, true);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
