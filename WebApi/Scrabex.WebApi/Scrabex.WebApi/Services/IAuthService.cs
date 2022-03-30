using Scrabex.WebApi.Dtos;

namespace Scrabex.WebApi.Services
{
    public interface IAuthService
    {
        bool TryLogin(HttpContext httpContext, LoginDto dto, out UserDto loggedUser);
        bool ForgotPassword(LoginDto dto);
        bool TryRegister(CreateUserDto dto, out UserDto registeredUser);
    }
}
