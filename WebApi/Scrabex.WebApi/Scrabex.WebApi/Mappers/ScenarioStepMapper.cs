using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class ScenarioStepMapper : IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto>
    {
        public ScenarioStepDto MapToDto(ScenarioStep model) => new ScenarioStepDto
        {
            Action = model.Action,
            AuthorId = model.AuthorId,
            Order = model.Order,
            StepId = model.StepId
        };

        public ScenarioStep MapToModel(CreateScenarioStepDto dto) => new ScenarioStep
        {
            Action = dto.Action,
            AuthorId = dto.AuthorId,
            Order = dto.Order
        };
    }
}
