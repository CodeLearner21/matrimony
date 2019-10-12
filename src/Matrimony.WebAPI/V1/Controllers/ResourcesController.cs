using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrimony.Core.Interfaces.UseCases;
using Matrimony.WebAPI.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.WebAPI.V1.Controllers
{
    [Authorize]
    [Route("api/V{v:apiVersion}/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IGetPortfolioListUseCase _getPortfolioListUseCase;
        private readonly PortfolioTypeListPresenter _portfolioTypeListPresenter;
        public ResourcesController(IGetPortfolioListUseCase getPortfolioListUseCase, PortfolioTypeListPresenter portfolioTypeListPresenter)
        {
            _getPortfolioListUseCase = getPortfolioListUseCase;
            _portfolioTypeListPresenter = portfolioTypeListPresenter;
        }

        [HttpGet]
        [Route("portfolio-types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetPortfolioTypes()
        {
            await _getPortfolioListUseCase.Handle(_portfolioTypeListPresenter);
            return _portfolioTypeListPresenter.ContentResult;
        }
    }
}