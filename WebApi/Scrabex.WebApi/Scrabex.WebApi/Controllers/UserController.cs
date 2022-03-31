using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Scrabex.WebApi.Attributes;
using Scrabex.WebApi.Constants;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.User;
using Scrabex.WebApi.Enums;
using Scrabex.WebApi.Models;
using Scrabex.WebApi.Services;
using System.Data;

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
        [Authorize(AccessLevels.Elevated)]
        public IActionResult GetUsers() => new JsonResult(new JArray(_service.GetAll().Select(p => JsonConvert.SerializeObject(p)).ToArray())) { StatusCode = 200 };

        
        [HttpGet("{id}")]
        [Authorize(AccessLevels.Standard, true)]
        public IActionResult GetUser(int id)
        {
            if (!_service.TryGet(id, out var foundUser))
                return new JsonResult(new JObject(UserMessages.ObjectNotFound)) { StatusCode = StatusCodes.Status404NotFound };

            if(foundUser.Id != id)
                return new JsonResult(new JObject(UserMessages.UnauthorizedRestricted)) { StatusCode = StatusCodes.Status401Unauthorized };

            return new JsonResult(JsonConvert.SerializeObject(foundUser)) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPost]
        [Authorize(AccessLevels.AnonConsent)]
        public IActionResult AddUser([FromBody] CreateUserDto userDto)
        {
            if (!_service.TryAdd(userDto, out var newUser))
                return new JsonResult(new JObject(UserMessages.ObjectCreateFailed)) { StatusCode = StatusCodes.Status404NotFound };

            return new JsonResult(JsonConvert.SerializeObject(newUser)) {  StatusCode= StatusCodes.Status202Accepted };
        }

        [HttpPut("{id}")]
        [Authorize(AccessLevels.Standard, true)]
        public IActionResult PutUser(int id, [FromBody] UpdateUserDto userDto)
        {
            if (!_service.TryGet(id, out var foundUser))
                return new JsonResult(new JObject(UserMessages.ObjectNotFound)) { StatusCode = StatusCodes.Status404NotFound };

            if (!_service.TryUpdate(id, userDto, out var newUser))
                return new JsonResult(new JObject(UserMessages.ObjectUpdateFailed)) { StatusCode = StatusCodes.Status404NotFound };

            return new JsonResult(JsonConvert.SerializeObject(newUser)) { StatusCode = StatusCodes.Status202Accepted };
        }

        [HttpDelete("{id}")]
        [Authorize(AccessLevels.Elevated, true)]
        public IActionResult DeleteUser(int id)
        {
            if (!_service.TryGet(id, out var foundUser))
                return new JsonResult(new JObject(UserMessages.ObjectNotFound)) { StatusCode = StatusCodes.Status404NotFound };

            if (!_service.TryDelete(id, out var deletedUser))
                return new JsonResult(new JObject(UserMessages.ObjectDeleteFailed)) { StatusCode = StatusCodes.Status404NotFound };

            return new JsonResult(JsonConvert.SerializeObject(deletedUser)) { StatusCode = StatusCodes.Status202Accepted };
        }
    }
}
