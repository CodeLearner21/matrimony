using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Matrimony.Core.Dtos.UseCaseRequests;
using Matrimony.Core.Interfaces.UseCases;
using Matrimony.Core.UseCases;
using Matrimony.WebAPI.Handlers.FileHandler;
using Matrimony.WebAPI.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.WebAPI.V1.Controllers
{
    [Authorize]
    [Route("api/V{v:apiVersion}/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly ICreatePortfolioUseCase _createPortfolioUseCase;
        private readonly CreatePortfolioPresenter _createPortfolioPresenter;
        private readonly IUploadProfilePhotoUseCase _uploadProfilePhotoUseCase;
        private readonly UploadProfilePhotoPresenter _uploadProfilePhotoPresenter;
        private readonly IGetUserPortfolioUseCase _getUserPortfolioUseCase;
        private readonly UserPortfolioPresenter _userPortfolioPresenter;
        private readonly IGetFilesByPortfolioIdUseCase _getFilesByPortfolioIdUseCase;
        private readonly PortfolioFilesPresenter _portfolioFilesPresenter;
        private readonly FileHandler _fileHandler;

        public PortfolioController(
            ICreatePortfolioUseCase createPortfolioUseCase, 
            CreatePortfolioPresenter createPortfolioPresenter, 
            IUploadProfilePhotoUseCase uploadProfilePhotoUseCase, 
            UploadProfilePhotoPresenter uploadProfilePhotoPresenter,
            IGetUserPortfolioUseCase getUserPortfolioUseCase,
            UserPortfolioPresenter userPortfolioPresenter,
            IGetFilesByPortfolioIdUseCase getFilesByPortfolioIdUseCase,
            PortfolioFilesPresenter portfolioFilesPresenter,
            FileHandler fileHandler)
        {
            _createPortfolioUseCase = createPortfolioUseCase;
            _createPortfolioPresenter = createPortfolioPresenter;
            _uploadProfilePhotoPresenter = uploadProfilePhotoPresenter;
            _uploadProfilePhotoUseCase = uploadProfilePhotoUseCase;
            _getUserPortfolioUseCase = getUserPortfolioUseCase;
            _userPortfolioPresenter = userPortfolioPresenter;
            _getFilesByPortfolioIdUseCase = getFilesByPortfolioIdUseCase;
            _portfolioFilesPresenter = portfolioFilesPresenter;
            _fileHandler = fileHandler;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] Models.Request.CreatePortfolioRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _createPortfolioUseCase.Handle(new CreatePortfolioRequest(request.FullName, request.Gender, request.BirthDate, request.UserId, request.PortfolioTypeId), _createPortfolioPresenter);
            return _createPortfolioPresenter.ContentResult;
        }

        
        [HttpPost]
        [Route("Photos")]
        public async Task<ActionResult> UploadPhoto(IFormFile file)
        {
            if (file == null)
                return BadRequest();

            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;            
            if (string.IsNullOrEmpty(userName))
                return Unauthorized(new JsonContentResult { StatusCode = 401, Content = "You do not have permission to this endpoint!", ContentType = "application/json" });

            var result = await _fileHandler.UploadUserFile(file, userName);
            if (result == null)
                return BadRequest(new JsonContentResult { StatusCode = 400, Content = "Something went wrong, please try again!", ContentType = "application/json" });

            await _uploadProfilePhotoUseCase.Handle(new UploadProfilePhotoRequest(result.Type, result.Title, result.Name, result.DirectoryName, result.DateCreated, userName), _uploadProfilePhotoPresenter);
            return _uploadProfilePhotoPresenter.ContentResult;
        }

        [HttpGet()]
        [Route("Photos")]
        public async Task<ActionResult> GetFiles(string portfolioId)
        {
            if(string.IsNullOrEmpty(portfolioId))
                return BadRequest(new JsonContentResult { StatusCode = 400, Content = "Portfolio id is required!", ContentType = "application/json" });

            await _getFilesByPortfolioIdUseCase.Handle(portfolioId, _portfolioFilesPresenter);
            return _portfolioFilesPresenter.ContentResult;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> Get(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest("User id is required");

            await _getUserPortfolioUseCase.Handle(userId, _userPortfolioPresenter);
            return _userPortfolioPresenter.ContentResult;
        }

    }
}