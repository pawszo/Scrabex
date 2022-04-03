using Scrabex.WebApi.Adapters;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.User;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class UserMapper : IMapper<User, CreateUserDto, UserDto, UpdateUserDto>
    {
        private readonly IConfigAdapter _config;

        public UserMapper(IConfigAdapter config)
        {
            _config = config;
        }

        public UserDto MapToDto(User model) => new()
        {
            Id = model.Id,
            UserTitle = model.UserTitle,
            AccessLevel = model.AccessLevel,
            CreatedAt = model.CreatedAt,
            CountryCode = model.CountryCode
        };

        public User CreateModel(CreateUserDto dto)
        {
            var user = new User
            {
                UserTitle = dto.UserTitle,
                CountryCode = dto.CountryCode,
                AccessLevel = (int)_config.DefaultAccessLevelOnRegister,
                CreatedAt = DateTime.Now
            };

            return user;
        }

        public void UpdateModel(User model, UpdateUserDto updateDto)
        {
            model.UserTitle = updateDto.UserTitle;
            model.CountryCode = updateDto.CountryCode;
        }
    }
}
