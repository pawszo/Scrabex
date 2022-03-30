using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class UserDetailMapper : IMapper<UserDetail, CreateUserDetailDto, UserDetailDto, UpdateUserDetailDto>
    {
        public UserDetail CreateModel(CreateUserDetailDto dto) => new UserDetail
        {
            LastUpdate = DateTime.Now,
            Login = dto.Login,
            Password = dto.Password,
            UserId = dto.UserId
        };

        public UserDetailDto MapToDto(UserDetail model)
        {
            if (model is null)
                return new UserDetailDto();

            return new UserDetailDto
            {
                Id = model.Id,
                ForgotPassword = model.ForgotPassword,
                LastUpdate = model.LastUpdate,
                Login = model.Login,
                Password = model.Password,
                UserId = model.UserId
            };
        }

        public void UpdateModel(UserDetail model, UpdateUserDetailDto updateDto)
        {
            model.LastUpdate = DateTime.Now;
            model.Password = updateDto.Password;
        }
    }
}
