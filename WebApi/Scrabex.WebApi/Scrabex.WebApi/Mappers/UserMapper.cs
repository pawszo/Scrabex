using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class UserMapper : IMapper<User, CreateUserDto, UserDto>
    {
        public UserDto MapToDto(User model) => new UserDto
        {
            UserId = model.UserId,
            UserTitle = model.UserTitle,
            Confirmed = model.Confirmed,
            CreatedAt = model.CreatedAt,
            CountryCode = model.CountryCode
        };

        public User MapToModel(CreateUserDto dto)
        {
            var user = new User
            {
                UserTitle = dto.UserTitle,
                CountryCode = dto.CountryCode
            };

            return user;
        }
    }
}
