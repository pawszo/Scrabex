using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class ScenarioMapper : 
        IMapper<Scenario, CreateScenarioDto, ScenarioDto>, 
        IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto>,
        IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto>
    {
        public ScenarioDto MapToDto(Scenario model) => new ScenarioDto
        {
            ScenarioId = model.ScenarioId,
            ScenarioGuid = model.ScenarioGuid,
            AuthorId = model.AuthorId,
            CreatedAt = model.CreatedAt
        };

        public ScenarioComponentDto MapToDto(ScenarioComponent model) => new ScenarioComponentDto
        {
            ComponentId = model.ComponentId,
            ScenarioId = model.ScenarioId,
            Query = model.Query,
            Name = model.Name
        };

        public ScenarioStepDto MapToDto(ScenarioStep model) => new ScenarioStepDto
        {
            Action = model.Action,
            AuthorId = model.AuthorId,
            Order = model.Order,
            StepId = model.StepId
        };

        public Scenario MapToModel(CreateScenarioDto dto) => new Scenario
        {
            //AuthorId = context.User.
        };

        public ScenarioComponent MapToModel(CreateScenarioComponentDto dto) => new ScenarioComponent
        {
            Name = dto.Name,
            Query = dto.Query,
            ScenarioId = dto.ScenarioId
        };

        public ScenarioStep MapToModel(CreateScenarioStepDto dto) => new ScenarioStep
        {
            AuthorId = dto.AuthorId,
            Action = dto.Action,
            Order = dto.Order
        };
    }
}
