﻿#nullable disable
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
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;
using Scrabex.WebApi.Services;

namespace Scrabex.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioController : ControllerBase
    {
        private readonly IObjectService<Scenario, CreateScenarioDto, ScenarioDto> _service;

        public ScenarioController(
            IObjectService<Scenario, CreateScenarioDto, ScenarioDto> service)
        {
            _service = service;
        }

        // GET: api/Scenario
        [HttpGet]
        public JsonResult GetScenarios()
        {
            //return await _dbContext.Scenarios.ToListAsync();

            var scenarios = new List<ScenarioDto>();
            var enumerator = _dbContext.Scenarios.GetAsyncEnumerator();
            while (enumerator.MoveNextAsync().Result)
            {
                var scenarioDto = _mapper.MapToDto(enumerator.Current);
                scenarios.Add(scenarioDto);
            }
            return new JsonResult(JArray.FromObject(scenarios.ToArray()));
        }

        // GET: api/Scenario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scenario>> GetScenario(int id)
        {
            var scenario = await _dbContext.Scenarios.FindAsync(id);

            if (scenario == null)
            {
                return NotFound();
            }

            return scenario;
        }

        // PUT: api/Scenario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScenario(int id, Scenario scenario)
        {
            if (id != scenario.ScenarioId)
            {
                return BadRequest();
            }

            _dbContext.Entry(scenario).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScenarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Scenario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scenario>> PostScenario(Scenario scenario)
        {
            _dbContext.Scenarios.Add(scenario);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetScenario", new { id = scenario.ScenarioId }, scenario);
        }

        // DELETE: api/Scenario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScenario(int id)
        {
            var scenario = await _dbContext.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }

            _dbContext.Scenarios.Remove(scenario);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ScenarioExists(int id)
        {
            return _dbContext.Scenarios.Any(e => e.ScenarioId == id);
        }
    }
}
