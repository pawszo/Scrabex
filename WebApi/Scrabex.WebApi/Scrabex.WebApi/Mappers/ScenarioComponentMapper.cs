using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class ScenarioComponentMapper : IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto>
    {
        public ScenarioComponentDto MapToDto(ScenarioComponent model) => new ScenarioComponentDto
        {
            ComponentId = model.ComponentId,
            Name = model.Name,
            Query = model.Query,
            ScenarioId = model.ScenarioId
        };

        public ScenarioComponent MapToModel(CreateScenarioComponentDto dto) => new ScenarioComponent
        {
            Name = dto.Name,
            Query = dto.Query,
            ScenarioId = dto.ScenarioId
        };
    }
}
