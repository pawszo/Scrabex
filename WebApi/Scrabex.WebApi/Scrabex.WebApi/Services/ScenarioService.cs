using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.Scenario;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Services
{
    public class ScenarioService : IObjectService<Scenario, CreateScenarioDto, ScenarioDto, UpdateScenarioDto>
    {
        private readonly IObjectServiceFacade _facade; 
        private readonly IMapper<Scenario, CreateScenarioDto, ScenarioDto, UpdateScenarioDto> _scenarioMapper; 
        private readonly IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto, UpdateScenarioComponentDto> _scenarioComponentMapper; 
        private readonly IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto, UpdateScenarioStepDto> _scenarioStepMapper;
        private readonly ScenarioContext _context;

        public ScenarioService(
            IObjectServiceFacade facade, 
            IMapper<Scenario, CreateScenarioDto, ScenarioDto, UpdateScenarioDto> scenarioMapper, 
            IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto, UpdateScenarioComponentDto> scenarioComponentMapper, 
            IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto, UpdateScenarioStepDto> scenarioStepMapper, 
            ScenarioContext context)
        {
            _facade = facade;
            _scenarioMapper = scenarioMapper;
            _scenarioComponentMapper = scenarioComponentMapper;
            _scenarioStepMapper = scenarioStepMapper;
            _context = context;
        }

        public IEnumerable<ScenarioDto> GetAll()
        {
            var scenarios = new List<ScenarioDto>();
            var enumerator = _context.Scenarios.GetAsyncEnumerator();
            while (enumerator.MoveNextAsync().Result)
            {
                var scenarioDto = _scenarioMapper.MapToDto(enumerator.Current);
                var scenarioComponents = _context.Components.Where(p => p.ScenarioId == scenarioDto.Id);
                var scenarioSteps = _context.Steps.Where(p => p.ScenarioId == scenarioDto.Id);
                scenarioDto.Steps = scenarioSteps.Select(p => _scenarioStepMapper.MapToDto(p)).ToArray();
                scenarioDto.Components = scenarioComponents.Select(p => _scenarioComponentMapper.MapToDto(p)).ToArray();
                scenarios.Add(scenarioDto);
            }
            enumerator.DisposeAsync();
            return scenarios;
        }

        public bool TryAdd(CreateScenarioDto dto, out ScenarioDto creationResult)
        {
            creationResult = null;
            if (!_facade.TryAdd(dto, _scenarioMapper, _context, out creationResult))
                return false;

            var scenarioId = creationResult.Id;

            dto.Steps.ToList().ForEach(p => p.ScenarioId = scenarioId);
            dto.Components.ToList().ForEach(p => p.ScenarioId = scenarioId);

            if (!_facade.TryAddAll(dto.Steps, _scenarioStepMapper, _context, out var addedSteps))
                return false;

            if (!_facade.TryAddAll(dto.Components, _scenarioComponentMapper, _context, out var addedComponents))
                return false;

            creationResult.Steps = addedSteps.ToArray();
            creationResult.Components = addedComponents.ToArray();

            return true;
        }

        public bool TryDelete(int id, out ScenarioDto removedObject)
        {
            throw new NotImplementedException();
        }

        public bool TryGet(int id, out ScenarioDto foundScenario)
        {
            foundScenario = null;

            if (!_facade.TryGet(id, _scenarioMapper, _context, out foundScenario))
                return false;

            foundScenario.Steps = _context.Steps.Select(p => _scenarioStepMapper.MapToDto(p)).ToArray();
            foundScenario.Components = _context.Components.Select(p => _scenarioComponentMapper.MapToDto(p)).ToArray();

            return true;
        }

        public bool TryGet(ScenarioDto searchedObject, out ScenarioDto foundObject)
        {
            return TryGet(searchedObject.Id, out foundObject);
        }


        public bool TryUpdate(int id, UpdateScenarioDto dto, out ScenarioDto updateResult)
        {
            updateResult = null;

            if (!_facade.TryUpdate(id, dto, _scenarioMapper, _context, out updateResult))
                return false;

            IList<ScenarioComponentDto> updatedComponents = new List<ScenarioComponentDto>();
            IList<ScenarioStepDto> updatedSteps = new List<ScenarioStepDto>();

            dto.Components.ToList().ForEach(p => p.ScenarioId = id);
            dto.Steps.ToList().ForEach(p => p.ScenarioId = id);

            if (dto.Components.Any() && !_facade.TryUpdateAll(
                dto.Components.ToDictionary(p => p.Id, p => p),
                _scenarioComponentMapper,
                _context,
                out updatedComponents)) return false;

            if (dto.Steps.Any() && !_facade.TryUpdateAll(
                dto.Steps.ToDictionary(p => p.Id, p => p),
                _scenarioStepMapper,
                _context,
                out updatedSteps)) return false;

            updateResult.Steps = updatedSteps.ToArray(); 
            updateResult.Components = updatedComponents.ToArray();

            return _context.SaveChanges() > 0;
        }
    }
}
