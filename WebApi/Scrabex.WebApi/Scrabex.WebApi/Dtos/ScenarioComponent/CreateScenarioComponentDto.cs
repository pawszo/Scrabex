using Newtonsoft.Json;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class CreateScenarioComponentDto
    {
        public string Name { get; set; }
        public string Query { get; set; }
        public int ScenarioId { get; set; }
        public string Symbol { get; set; }
    }
}
