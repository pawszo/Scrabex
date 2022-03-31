using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.Authentication;

namespace Scrabex.WebApi.Services
{
    public interface IAuthService
    {
        bool TryLogin(LoginDto dto, out AuthenticationResponse authenticationResponse);
        bool ForgotPassword(LoginDto dto);
        bool TryRegister(CreateUserDto dto, out UserDto registeredUser);
        bool TryLogout(HttpContext context, out string login);
    }
}
