using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Dtos.Scenario;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class ScenarioMapper : IMapper<Scenario, CreateScenarioDto, ScenarioDto, UpdateScenarioDto>
    {
        public ScenarioDto MapToDto(Scenario model) => new ScenarioDto
        {
            Id = model.Id,
            ScenarioGuid = model.ScenarioGuid,
            AuthorId = model.AuthorId,
            CreatedAt = model.CreatedAt
        };

        public ScenarioComponentDto MapToDto(ScenarioComponent model) => new ScenarioComponentDto
        {
            Id = model.Id,
            ScenarioId = model.ScenarioId,
            Query = model.Query,
            Name = model.Name
        };

        public ScenarioStepDto MapToDto(ScenarioStep model) => new ScenarioStepDto
        {
            Action = model.Action,
            Order = model.Order,
            Id = model.Id,
            ScenarioId = model.ScenarioId
        };

        public Scenario CreateModel(CreateScenarioDto dto) => new Scenario
        {
            AuthorId = dto.AuthorId
        };

        public ScenarioComponent MapToModel(CreateScenarioComponentDto dto) => new ScenarioComponent
        {
            Name = dto.Name,
            Query = dto.Query,
            ScenarioId = dto.ScenarioId
        };

        public ScenarioStep MapToModel(CreateScenarioStepDto dto) => new ScenarioStep
        {
            Action = dto.Action,
            Order = dto.Order,
            ScenarioId = dto.ScenarioId
        };

        public void UpdateModel(Scenario model, UpdateScenarioDto updateDto)
        {
            model.AuthorId = updateDto.AuthorId;
        }
    }
}
