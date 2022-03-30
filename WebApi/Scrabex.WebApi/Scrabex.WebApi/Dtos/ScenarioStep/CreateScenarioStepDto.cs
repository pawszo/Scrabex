using Newtonsoft.Json;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class CreateScenarioStepDto
    {
        public int Order { get; set; }
        public string Action { get; set; }
        public int ScenarioId { get; set; }
    }
}
