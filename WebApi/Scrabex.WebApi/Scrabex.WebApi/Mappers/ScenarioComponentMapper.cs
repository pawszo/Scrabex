using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class ScenarioComponentMapper : IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto, UpdateScenarioComponentDto>
    {
        public ScenarioComponentDto MapToDto(ScenarioComponent model) => new ScenarioComponentDto
        {
            Id = model.Id,
            Name = model.Name,
            Query = model.Query,
            ScenarioId = model.ScenarioId
        };

        public ScenarioComponent CreateModel(CreateScenarioComponentDto dto) => new ScenarioComponent
        {
            Name = dto.Name,
            Query = dto.Query,
            ScenarioId = dto.ScenarioId
        };

        public void UpdateModel(ScenarioComponent model, UpdateScenarioComponentDto updateDto)
        {
            model.Query = updateDto.Query;
            model.Name = updateDto.Name;
        }
    }
}
