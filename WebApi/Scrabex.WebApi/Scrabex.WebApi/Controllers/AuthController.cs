using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Scrabex.WebApi.Attributes;
using Scrabex.WebApi.Constants;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Enums;
using Scrabex.WebApi.Services;

namespace Scrabex.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/api/register")]
        [Authorize(AccessLevel.Anon)]
        //[Authorize(AccessLevels.AnonConsent)]
        public IActionResult Register([FromBody] CreateUserDto userDto)
        {
            if (!_authService.TryRegister(userDto, out var newUser))
                return new JsonResult(UserMessages.RegisterFailed) { StatusCode = StatusCodes.Status406NotAcceptable };

            return new JsonResult(newUser) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPost("/api/login")]
        [Authorize(AccessLevel.Anon)]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            if (dto.ForgotPassword)
            {
                if(!_authService.ForgotPassword(dto))
                    return new JsonResult(UserMessages.ChangePasswordEmailError) { StatusCode = StatusCodes.Status400BadRequest };

                return new JsonResult(UserMessages.ChangePasswordEmailSent) { StatusCode = StatusCodes.Status202Accepted };
            }

            if (!_authService.TryLogin(dto, out var loggedUser))
                return new JsonResult(UserMessages.LoginFailed) { StatusCode = StatusCodes.Status406NotAcceptable };

            return new JsonResult(loggedUser) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("/api/logout")]
        [Authorize(AccessLevel.Standard)]
        public IActionResult Logout()
        {
            if(!_authService.TryLogout(HttpContext, out string login))
                return new JsonResult(UserMessages.LogoutFailed) { StatusCode = StatusCodes.Status400BadRequest};

            return new JsonResult(UserMessages.LogoutSuccessful + login) { StatusCode = StatusCodes.Status202Accepted };
        }
    }
}
