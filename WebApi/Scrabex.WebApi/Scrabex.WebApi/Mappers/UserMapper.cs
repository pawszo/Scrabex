﻿using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.User;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class UserMapper : IMapper<User, CreateUserDto, UserDto, UpdateUserDto>
    {
        public UserDto MapToDto(User model) => new UserDto
        {
            Id = model.Id,
            UserTitle = model.UserTitle,
            Confirmed = model.Confirmed,
            CreatedAt = model.CreatedAt,
            CountryCode = model.CountryCode
        };

        public User CreateModel(CreateUserDto dto)
        {
            var user = new User
            {
                UserTitle = dto.UserTitle,
                CountryCode = dto.CountryCode,
                Confirmed = false,
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
