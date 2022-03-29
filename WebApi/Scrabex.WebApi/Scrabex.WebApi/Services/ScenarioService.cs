using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Services
{
    public class ScenarioService : IObjectService<Scenario, CreateScenarioDto, ScenarioDto>
    {
        private readonly IObjectServiceFacade _facade; 
        private readonly IMapper<Scenario, CreateScenarioDto, ScenarioDto> _scenarioMapper; 
        private readonly IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto> _scenarioComponentMapper; 
        private readonly IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto> _scenarioStepMapper;
        private readonly ScenarioContext _context;

        public ScenarioService(
            IObjectServiceFacade facade, 
            IMapper<Scenario, CreateScenarioDto, ScenarioDto> scenarioMapper, 
            IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto> scenarioComponentMapper, 
            IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto> scenarioStepMapper, 
            ScenarioContext context)
        {
            _facade = facade;
            _scenarioMapper = scenarioMapper;
            _scenarioComponentMapper = scenarioComponentMapper;
            _scenarioStepMapper = scenarioStepMapper;
            _context = context;
        }

        public Task<IEnumerable<ScenarioDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool TryAdd(CreateScenarioDto dto, out ScenarioDto creationResult)
        {
            throw new NotImplementedException();
        }

        public bool TryDelete(int id, out ScenarioDto removedObject)
        {
            throw new NotImplementedException();
        }

        public bool TryGet(int id, out ScenarioDto foundObject)
        {
            throw new NotImplementedException();
        }

        public bool TryUpdate(int id, IDictionary<string, object> properties, out ScenarioDto updateResult)
        {
            throw new NotImplementedException();
        }
    }
}
