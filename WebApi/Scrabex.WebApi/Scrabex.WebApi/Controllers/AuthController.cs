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
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/register")]
        [Authorize(AccessLevels.AnonConsent)]
        public IActionResult Register([FromBody] CreateUserDto userDto)
        {
            if (!_authService.TryRegister(userDto, out var newUser))
                return new JsonResult(UserMessages.RegisterFailed) { StatusCode = StatusCodes.Status406NotAcceptable };

            return new JsonResult(JsonConvert.SerializeObject(newUser)) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPost("/login")]
        [Authorize(AccessLevels.Anon)]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            if (dto.ForgotPassword)
            {
                if(!_authService.ForgotPassword(dto))
                    return new JsonResult(new JObject(UserMessages.ChangePasswordEmailError)) { StatusCode = StatusCodes.Status400BadRequest };

                return new JsonResult(new JObject(UserMessages.ChangePasswordEmailSent)) { StatusCode = StatusCodes.Status202Accepted };
            }

            if (!_authService.TryLogin(dto, out var loggedUser))
                return new JsonResult(UserMessages.LoginFailed) { StatusCode = StatusCodes.Status406NotAcceptable };

            return new JsonResult(JsonConvert.SerializeObject(loggedUser)) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("/logout")]
        [Authorize(AccessLevels.Standard)]
        public IActionResult Logout(HttpContext context)
        {
            if(!_authService.TryLogout(context, out string login))
                return new JsonResult(UserMessages.LogoutFailed) { StatusCode = StatusCodes.Status400BadRequest};

            return new JsonResult(UserMessages.LogoutSuccessful + login) { StatusCode = StatusCodes.Status202Accepted };
        }
    }
}
