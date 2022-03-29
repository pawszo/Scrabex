using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class UserDetailMapper : IMapper<UserDetail, CreateUserDetailDto, UserDetailDto>
    {
        public UserDetail MapToModel(CreateUserDetailDto dto) => new UserDetail
        {
            LastUpdate = DateTime.Now,
            Login = dto.Login,
            Password = dto.Password,
            UserId = dto.UserId
        };

        public UserDetailDto MapToDto(UserDetail model) => new UserDetailDto
        {
            UserId = model.UserId,
            ForgotPassword = model.ForgotPassword,
            LastUpdate = model.LastUpdate,
            Login = model.Login,
            Password = model.Password
        };
    }
}
