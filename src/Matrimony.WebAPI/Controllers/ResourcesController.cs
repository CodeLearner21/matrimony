using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ResourcesController : ControllerBase
    {
        private readonly IGetAllReligionsUserCase _getAllReligionsUserCase;
        private readonly ReligionsListPresenter _religionsListPresenter;
        public ResourcesController(IGetAllReligionsUserCase getAllReligionsUserCase, ReligionsListPresenter religionsListPresenter)
        {
            _getAllReligionsUserCase = getAllReligionsUserCase;
            _religionsListPresenter = religionsListPresenter;
        }

        [HttpGet]
        [Route("religions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllReligions()
        {
            await _getAllReligionsUserCase.Handle(_religionsListPresenter);
            return _religionsListPresenter.ContentResult;
        }
    }
}