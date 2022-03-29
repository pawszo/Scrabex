using Newtonsoft.Json;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class ScenarioComponentDto
    {
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public int ScenarioId { get; set; }
    }
}
