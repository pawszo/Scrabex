using Microsoft.IdentityModel.Tokens;
using Scrabex.WebApi.Adapters;
using Scrabex.WebApi.Constants;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.User;
using Scrabex.WebApi.Models;
using Scrabex.WebApi.Services;
using System.IdentityModel.Tokens.Jwt;

namespace Scrabex.WebApi.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfigAdapter _config;

        public JwtMiddleware(RequestDelegate next, IConfigAdapter config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context, IObjectService<User,CreateUserDto, UserDto, UpdateUserDto> userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, userService, token);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IObjectService<User, CreateUserDto, UserDto, UpdateUserDto> userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = _config.JwtKey;
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                if(userService.TryGet(userId, out var foundUser))
                {
                    context.Items[ContextProperties.User] = foundUser;
                    context.Items[ContextProperties.AccessLevel] = foundUser.AccessLevel;
                }
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}