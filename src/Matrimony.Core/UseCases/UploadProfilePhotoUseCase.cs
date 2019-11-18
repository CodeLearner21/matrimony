using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Dtos.UseCaseRequests;
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
    public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        public UploadProfilePhotoUseCase(IUserRepository userRepository, IPortfolioRepository portfolioRepository)
        {
            _userRepository = userRepository;
            _portfolioRepository = portfolioRepository;
        }

        public async Task<bool> Handle(UploadProfilePhotoRequest request, IOutputPort<UploadProfilePhotoResponse> outputPort)
        {
            var user = await _userRepository.FindByName(request.UserName);
            if (user == null)
                return false;

            var userPortfolio = await _portfolioRepository.FindByUserName(user.UserName);

            var response = await _portfolioRepository.AddFile(new PortfolioFile(request.Type, request.Title, request.Name, request.DirectoryName, request.DateCreated, userPortfolio.Id));
            outputPort.Handle(response.Success ? new UploadProfilePhotoResponse(response.Id, true) : new UploadProfilePhotoResponse(response.Errors.Select(e => e.Description)));

            return response.Success;
        }
    }
}
