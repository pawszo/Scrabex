using Microsoft.IdentityModel.Tokens;
using Scrabex.WebApi.Adapters;
using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.Authentication;
using Scrabex.WebApi.Dtos.User;
using Scrabex.WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Scrabex.WebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserContext _context;
        private readonly IConfigAdapter _configuration;
        private readonly IHashService _hashService;
        private readonly IObjectService<User, CreateUserDto, UserDto, UpdateUserDto> _userService;

        public AuthService(
            UserContext context,
            IConfigAdapter configuration, 
            IHashService hashService, 
            IObjectService<User, CreateUserDto, UserDto, UpdateUserDto> userService)
        {
            _context = context;
            _configuration = configuration;
            _hashService = hashService;
            _userService = userService;
        }

        public bool ForgotPassword(LoginDto dto)
        {
            throw new NotImplementedException();
        }


        public bool TryLogin(LoginDto dto, out AuthenticationResponse authResponse)
        {
            authResponse = null;

            if (string.IsNullOrWhiteSpace(dto.Login) || string.IsNullOrWhiteSpace(dto.Password))
                return false;

            var foundUserDetail = _context.UserDetails.FirstOrDefault(p => p.Login == dto.Login && p.Password == _hashService.GetHash(dto.Password));

            if (foundUserDetail == null || !_userService.TryGet(foundUserDetail.UserId, out var foundUser))
                return false;

            var token = GenerateJwtToken(foundUser);
            authResponse = new AuthenticationResponse { Id = foundUser.Id, Login = foundUser.Details.Login, Token = token };
            return true;
        }

        public bool TryRegister(CreateUserDto dto, out UserDto registeredUser)
        {
            throw new NotImplementedException();
        }

        public bool TryLogout(HttpContext context, out string login)
        {
            login = (context.Items["User"] as UserDto)?.Details?.Login ?? String.Empty;
            return string.IsNullOrEmpty(login);
        }

        private string GenerateJwtToken(UserDto user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = _configuration.JwtKey;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
