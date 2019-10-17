using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly ICurrentUserUseCase _currentUserUseCase;

        private readonly RegisterUserPresenter _registerUserPresenter;
        private readonly LoginPresenter _loginPresenter;
        private readonly PasswordResetPresenter _passwordResetPresenter;
        private readonly CurrentUserPresenter _currentUserPresenter;
        

        public AccountController(IRegisterUserUseCase registerUserUseCase, 
            RegisterUserPresenter registerUserPresenter, 
            ILoginUserUsecase loginUserUsecase, 
            ICurrentUserUseCase currentUserUseCase,
            LoginPresenter loginPresenter,
            IResetPasswordUseCase resetPasswordUseCase,
            PasswordResetPresenter passwordResetPresenter,
            CurrentUserPresenter currentUserPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
            _loginUserUsecase = loginUserUsecase;
            _currentUserUseCase = currentUserUseCase;
            _loginPresenter = loginPresenter;
            _currentUserPresenter = currentUserPresenter;
            _resetPasswordUseCase = resetPasswordUseCase;
            _passwordResetPresenter = passwordResetPresenter;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
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
        [Route("Login")]
        public async Task<ActionResult> Post([FromBody] Models.Request.LoginUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _loginUserUsecase.Handle(new LoginRequest(request.Email, request.Password), _loginPresenter);
            return _loginPresenter.ContentResult;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PasswordReset")]
        public async Task<ActionResult> Post([FromBody] Models.Request.ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _resetPasswordUseCase.Handle(new PasswordResetRequest(request.Email), _passwordResetPresenter);
            return _passwordResetPresenter.ContentResult;
        }
               
        
        [HttpGet]
        [Route("CurrentUser")]
        public async Task<ActionResult> GetCurrentUser()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(userName))
                Unauthorized(new JsonContentResult { StatusCode = 401, Content = "You do not have permission to this endpoint!", ContentType = "application/json" });

            await _currentUserUseCase.Handle(new CurrentUserRequest(userName), _currentUserPresenter);
            return _currentUserPresenter.ContentResult;
        }
    }
}