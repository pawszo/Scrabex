using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Scrabex.WebApi.Constants;
using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.User;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;
using Scrabex.WebApi.Services;
using System.Data;
using System.Data.SqlClient;

namespace Scrabex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IObjectService<User, CreateUserDto, UserDto, UpdateUserDto> _service;

        public UserController(
            IConfiguration configuration, 
            IObjectService<User,CreateUserDto,UserDto, UpdateUserDto> userService)
        {
            _config = configuration;
            _service = userService;
        }

        [HttpGet]
        public IActionResult GetUsers() => new JsonResult(new JArray(_service.GetAll().Select(p => JsonConvert.SerializeObject(p)).ToArray()));

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if (!_service.TryGet(id, out var foundUser))
                return new NotFoundObjectResult(id);

            return new JsonResult(JsonConvert.SerializeObject(foundUser));
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserDto userDto)
        {
            if (!_service.TryAdd(userDto, out var newUser))
                return  new NotFoundResult();

            return new JsonResult(JsonConvert.SerializeObject(newUser));
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] UpdateUserDto userDto)
        {
            if (!_service.TryUpdate(id, userDto, out var newUser))
                return new NotFoundObjectResult(id);

            return new JsonResult(JsonConvert.SerializeObject(newUser));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (!_service.TryDelete(id, out var deletedUser))
                return new NotFoundObjectResult(id);

            return new JsonResult(JsonConvert.SerializeObject(deletedUser));
        }


    }
}
