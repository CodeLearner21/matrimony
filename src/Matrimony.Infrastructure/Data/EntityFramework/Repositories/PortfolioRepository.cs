using AutoMapper;
using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.GatewayResponses;
using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Infrastructure.Data.EntityFramework.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PortfolioRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PortfolioAddedResponse> Create(UserPortfolio userPortfolio)
        {
            bool success = false;
            var portfolio = _mapper.Map<Portfolio>(userPortfolio);
            List<ResponseError> responseErrors = new List<ResponseError>();

            try
            {                
                _context.Portfolios.Add(portfolio);
                await _context.SaveChangesAsync();
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                responseErrors.Add(new ResponseError("400", e.Message));
                throw;
            }

            return new PortfolioAddedResponse(portfolio.Id, success, responseErrors);
        }
    }
}
