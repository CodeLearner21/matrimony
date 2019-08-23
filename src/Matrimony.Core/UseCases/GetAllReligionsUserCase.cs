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
    public class GetAllReligionsUserCase : IGetAllReligionsUserCase
    {
        public readonly IReligionRepository _religionRepository;
        public GetAllReligionsUserCase(IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;
        }

        public async Task<bool> Handle(IOutputPort<ReligionsListResponse> outputPort)
        {
            var response = await _religionRepository.GetAll();
            outputPort.Handle(response.Success ? new ReligionsListResponse(response.Religions, true) : new ReligionsListResponse(response.Errors.Select(e => e.Description)));

            return response.Success;
        }
    }
}
