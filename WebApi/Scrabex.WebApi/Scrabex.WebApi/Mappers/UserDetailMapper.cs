using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;
using Scrabex.WebApi.Services;

namespace Scrabex.WebApi.Mappers
{
    public class UserDetailMapper : IMapper<UserDetail, CreateUserDetailDto, UserDetailDto, UpdateUserDetailDto>
    {
        private readonly IHashService _hashService;

        public UserDetailMapper(IHashService hashService)
        {
            _hashService = hashService;
        }

        public UserDetail CreateModel(CreateUserDetailDto dto) => new UserDetail
        {
            LastUpdate = DateTime.Now,
            Login = dto.Login,
            Password = _hashService.GetHash(dto.Password),
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
            model.Password = _hashService.GetHash(updateDto.Password);
        }
    }
}
