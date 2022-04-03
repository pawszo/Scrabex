using Newtonsoft.Json;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Dtos.Scenario
{
    [JsonObject]
    public class UpdateScenarioDto : CreateScenarioDto, IEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public new UpdateScenarioComponentDto[] Components { get; set; }
        public new UpdateScenarioStepDto[] Steps { get; set; }
    }
}
