using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Mappers
{
    public class ScenarioStepMapper : IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto, UpdateScenarioStepDto>
    {
        public ScenarioStepDto MapToDto(ScenarioStep model) => new ScenarioStepDto
        {
            Action = model.Action,
            Order = model.Order,
            Id = model.Id,
            ScenarioId = model.ScenarioId
        };

        public ScenarioStep CreateModel(CreateScenarioStepDto dto) => new ScenarioStep
        {
            Action = dto.Action,
            Order = dto.Order
        };

        public void UpdateModel(ScenarioStep model, UpdateScenarioStepDto updateDto)
        {
            model.Action = updateDto.Action;
            model.Order = updateDto.Order;
        }
    }
}
