using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrimony.Core.Dtos.UseCaseRequests;
using Matrimony.Core.Interfaces.UseCases;
using Matrimony.WebAPI.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly ICreatePortfolioUseCase _createPortfolioUseCase;
        private readonly CreatePortfolioPresenter _createPortfolioPresenter;


        public PortfolioController(ICreatePortfolioUseCase createPortfolioUseCase, CreatePortfolioPresenter createPortfolioPresenter)
        {
            _createPortfolioUseCase = createPortfolioUseCase;
            _createPortfolioPresenter = createPortfolioPresenter;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] Models.Request.CreatePortfolioRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _createPortfolioUseCase.Handle(new CreatePortfolioRequest(request.FullName, request.UserId, request.PortfolioTypeId, request.SubCasteId), _createPortfolioPresenter);
            return _createPortfolioPresenter.ContentResult;
        }
    }
}