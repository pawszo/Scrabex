using Newtonsoft.Json;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class CreateScenarioDto
    {
        public IEnumerable<CreateScenarioComponentDto> Components { get; set; }
        public IEnumerable<ScenarioStep> Steps { get; set; }
    }
}
