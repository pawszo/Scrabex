#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.Scenario;
using Scrabex.WebApi.Mappers;
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

        // GET: api/Scenario
        [HttpGet]
        public IActionResult GetScenarios()
        {
            var scenarios = _service.GetAll();
            return new JsonResult(JsonConvert.SerializeObject(scenarios.ToArray()));
        }

        // GET: api/Scenario/5
        [HttpGet("{id}")]
        public IActionResult GetScenario(int id)
        {
            if(!_service.TryGet(id, out var foundObject))
            {
                return new NotFoundResult();
            }

            return new JsonResult(JsonConvert.SerializeObject(foundObject));
        }

        // PUT: api/Scenario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutScenario(int id, [FromBody] UpdateScenarioDto dto)
        {
            if (!_service.TryUpdate(id, dto, out var updatedScenario))
                return new UnprocessableEntityResult();

            return new JsonResult(JsonConvert.SerializeObject(updatedScenario));
        }

        // POST: api/Scenario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostScenario([FromBody] CreateScenarioDto scenarioDto)
        {
            if (!_service.TryAdd(scenarioDto, out var newScenario))
                return new UnprocessableEntityResult();

            return new JsonResult(JsonConvert.SerializeObject(newScenario));
        }

        // DELETE: api/Scenario/5
        [HttpDelete("{id}")]
        public IActionResult DeleteScenario(int id)
        {
            if(!_service.TryDelete(id, out var removedObject))
                return new NotFoundResult();

            return new JsonResult(JsonConvert.SerializeObject(removedObject));
        }

    }
}
