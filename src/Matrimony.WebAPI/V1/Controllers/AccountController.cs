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

namespace Matrimony.WebAPI.V1.Controllers
{
    [Authorize]
    [Route("api/V{v:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly ILoginUserUsecase _loginUserUsecase;
        private readonly IResetPasswordUseCase _resetPasswordUseCase;
        private readonly RegisterUserPresenter _registerUserPresenter;
        private readonly LoginPresenter _loginPresenter;
        private readonly PasswordResetPresenter _passwordResetPresenter;
        public AccountController(IRegisterUserUseCase registerUserUseCase, 
            RegisterUserPresenter registerUserPresenter, 
            ILoginUserUsecase loginUserUsecase, 
            LoginPresenter loginPresenter,
            IResetPasswordUseCase resetPasswordUseCase,
            PasswordResetPresenter passwordResetPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
            _loginUserUsecase = loginUserUsecase;
            _loginPresenter = loginPresenter;
            _resetPasswordUseCase = resetPasswordUseCase;
            _passwordResetPresenter = passwordResetPresenter;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Post([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.Handle(new RegisterUserRequest(request.FirstName, request.LastName, request.Email, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Post([FromBody] Models.Request.LoginUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _loginUserUsecase.Handle(new LoginRequest(request.Email, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("password-reset")]
        public async Task<ActionResult> Post([FromBody] Models.Request.ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _resetPasswordUseCase.Handle(new PasswordResetRequest(request.Email), _passwordResetPresenter);
            return _passwordResetPresenter.ContentResult;
        }
    }
}