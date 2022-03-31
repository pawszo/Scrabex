#nullable disable
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Scrabex.WebApi.Attributes;
using Scrabex.WebApi.Constants;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.Scenario;
using Scrabex.WebApi.Enums;
using Scrabex.WebApi.Models;
using Scrabex.WebApi.Services;

namespace Scrabex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ScenarioController : ControllerBase
    {
        private readonly IObjectService<Scenario, CreateScenarioDto, ScenarioDto, UpdateScenarioDto> _service;

        public ScenarioController(
            IObjectService<Scenario, CreateScenarioDto, ScenarioDto, UpdateScenarioDto> service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(AccessLevel.Elevated)]
        public IActionResult GetScenarios()
        {
            return new JsonResult(_service.GetAll()) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet]
        [Route("user/{userId}")]
        [Authorize(AccessLevel.Standard,true)]
        public IActionResult GetUserScenarios(int userId)
        {
            var scenarios = _service.GetAll().Where(p => p.AuthorId == userId);
            return new JsonResult(scenarios) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(AccessLevel.Elevated, true)]
        public IActionResult GetScenario(int id)
        {
            if(!_service.TryGet(id, out var foundObject))
            {
                return new JsonResult(UserMessages.ObjectNotFound) { StatusCode = StatusCodes.Status404NotFound };
            }

            return new JsonResult(foundObject) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet]
        [Route("{id}/user/{userId}")]
        [Authorize(AccessLevel.Standard, true)]
        public IActionResult GetUserScenario(int id, int userId)
        {
            if (!_service.TryGet(id, out var foundObject))
            {
                return new JsonResult(UserMessages.ObjectNotFound) { StatusCode = StatusCodes.Status404NotFound };
            }

            if(foundObject.AuthorId != userId)
                return new JsonResult(UserMessages.UnauthorizedRestricted) { StatusCode = StatusCodes.Status401Unauthorized };

            return new JsonResult(foundObject) { StatusCode = StatusCodes.Status200OK };
        }


        [HttpPut]
        [Route("{id}")]
        [Authorize(AccessLevel.Super)]
        public IActionResult PutScenario(int id, [FromBody] UpdateScenarioDto dto)
        {
            if (!_service.TryUpdate(id, dto, out var updatedScenario))
                return new JsonResult(UserMessages.ObjectUpdateFailed) { StatusCode = StatusCodes.Status404NotFound };

            return new JsonResult(updatedScenario) { StatusCode = StatusCodes.Status202Accepted };
        }

        [HttpPut]
        [Route("{id}/user/{userId}")]
        [Authorize(AccessLevel.Standard, true)]
        public IActionResult PutUserScenario(int id, int userId, [FromBody] UpdateScenarioDto dto)
        {
            if(_service.TryGet(id, out var currentObject) && currentObject.AuthorId != userId)
                return new JsonResult(UserMessages.UnauthorizedRestricted) { StatusCode = StatusCodes.Status401Unauthorized };

            if (_service.TryUpdate(id, dto, out var updatedScenario))
                return new JsonResult(updatedScenario) { StatusCode = StatusCodes.Status202Accepted };
                
            return new JsonResult(UserMessages.ObjectUpdateFailed) { StatusCode = StatusCodes.Status404NotFound };


        }

        [HttpPost]
        [Authorize(AccessLevel.Standard)]
        public IActionResult PostScenario([FromBody] CreateScenarioDto scenarioDto)
        {
            scenarioDto.AuthorId = (HttpContext.Items[ContextProperties.User] as IEntity).Id;

            if (!_service.TryAdd(scenarioDto, out var newScenario))
                return new JsonResult(UserMessages.ObjectCreateFailed) { StatusCode = StatusCodes.Status404NotFound };

            return new JsonResult(newScenario) { StatusCode = StatusCodes.Status202Accepted };
        }

        [HttpDelete]
        [Route("{id}/user/{userId}")]
        [Authorize(AccessLevel.Elevated, true)]
        public IActionResult DeleteScenario(int id, int userId)
        {
            if(_service.TryGet(id, out var foundObject) && foundObject.AuthorId != userId)
                return new JsonResult(UserMessages.UnauthorizedRestricted) { StatusCode = StatusCodes.Status401Unauthorized };


            if (_service.TryDelete(id, out var removedObject))
                return new JsonResult(removedObject) { StatusCode = StatusCodes.Status202Accepted };

            return new JsonResult(UserMessages.ObjectDeleteFailed) { StatusCode = StatusCodes.Status404NotFound };
        }
    }
}
