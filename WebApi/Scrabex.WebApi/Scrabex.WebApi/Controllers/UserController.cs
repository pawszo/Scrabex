using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Scrabex.WebApi.Constants;
using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;
using Scrabex.WebApi.Services;
using System.Data;
using System.Data.SqlClient;

namespace Scrabex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IControllerFacade _facade;
        private readonly IObjectService<User, CreateUserDto, UserDto> _service;
        public UserController(
            IConfiguration configuration, 
            IControllerFacade facade,
            IObjectService<User,CreateUserDto,UserDto> userService)
        {
            _config = configuration;
            _facade = facade;
            _service = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _service.GetAll();
            return await new Task<JsonResult>( () => new JsonResult(users.Result.ToArray()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDto), 201)]
        public IActionResult AddUser([FromBody] CreateUserDto userDto)
        {
            var user = _dbContext.Add(_mapper.MapToModel(userDto));
            userDto.Details.UserId = user.Entity.UserId;
            var userDetails = _dbContext.Add(userDto.Details);

            var dto = _mapper.MapToDto(user.Entity);
            dto.Details = userDetails.Entity;
            return new JsonResult(dto);
        }


    }
}
