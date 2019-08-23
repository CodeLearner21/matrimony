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
    public class ReligionRepository : IReligionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReligionRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReligionsListResponseGateway> GetAll()
        {
            var religions = await _context.Religions.Include(r => r.Communities).ThenInclude(c => c.Castes).ThenInclude(c => c.SubCastes).ToListAsync();
            var religionList = _mapper.Map<IEnumerable<ReligionEntity>>(religions);
            if(religions != null)
            {
                return new ReligionsListResponseGateway(religionList, true, null);
            }
            List<ResponseError> responseErrors = new List<ResponseError>();
            responseErrors.Add(new ResponseError("404", "No religions found in database"));
            return new ReligionsListResponseGateway(null, false, responseErrors);
        }
    }
}
