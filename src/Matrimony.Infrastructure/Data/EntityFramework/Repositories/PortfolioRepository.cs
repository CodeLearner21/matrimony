using AutoMapper;
using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.GatewayResponses;
using Matrimony.Core.Dtos.GatewayResponses.Repositories;
using Matrimony.Core.Interfaces.Gateways;
using Matrimony.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Infrastructure.Data.EntityFramework.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PortfolioRepository> _logger;

        public PortfolioRepository(ApplicationDbContext context, IMapper mapper, ILogger<PortfolioRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
                responseErrors.Add(new ResponseError("400", e.Message));
                throw;
            }

            return new PortfolioAddedResponse(portfolio.Id.ToString(), success, responseErrors);
        }

        public async Task<FileCreatedResponse> AddFile(PortfolioFile userFile)
        {
            var success = false;
            List<ResponseError> responseErrors = new List<ResponseError>();
            var file = _mapper.Map<PortfolioDocument>(userFile);
            try
            {
                //_context.Entry<Portfolio>(file.Portfolio).State = EntityState.Unchanged;
                await _context.Files.AddAsync(file);
                await _context.SaveChangesAsync();
                success = true;
                responseErrors = null;
            }
            catch (Exception ex)
            {
                responseErrors.Add(new ResponseError("500", "File not uploaded! Please try again"));
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }

            return new FileCreatedResponse(file.Id.ToString(), success, responseErrors);
        }

        public async Task<UserPortfolio> FindByUserName(string userName)
        {
            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(p => p.AppUser.UserName == userName);
            return _mapper.Map<UserPortfolio>(portfolio);
        }

        public async Task<GetPortfolioByUserIdResponse> GetByUserId(string userId)
        {
            try
            {
                var portfolio = await _context.Portfolios.Include(p => p.Files).SingleOrDefaultAsync(p => p.AppUser.Id == userId);
                if(portfolio == null)
                {
                    List<ResponseError> errors = new List<ResponseError>();
                    errors.Add(new ResponseError("404", "User portfolio not found"));
                    return new GetPortfolioByUserIdResponse(null, false, errors);
                }

                return new GetPortfolioByUserIdResponse(_mapper.Map<UserPortfolio>(portfolio), true, null);
            }
            catch (Exception)
            {
                _logger.LogError("Unable to get portfolio by user id: {0}", userId);
            }
            return null;
        }

        public async Task<GetFilesResponse> GetFilesById(string portfolioId)
        {
            var portfolio = await _context.Portfolios.Include(p => p.Files).SingleOrDefaultAsync(p => p.Id == Guid.Parse(portfolioId));
            if (portfolio == null || portfolio.Files == null) 
            {
                var errors = new List<ResponseError>();
                errors.Add(new ResponseError("404", string.Format("Portofolio files not found")));
                return new GetFilesResponse(null, false, errors);
            }
            var files = _mapper.Map<IEnumerable<PortfolioFile>>(portfolio.Files);
            return new GetFilesResponse(files, true, null);
        }
    }
}
