using Newtonsoft.Json;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class CreateScenarioDto
    {
        public CreateScenarioComponentDto[] Components { get; set; }
        public CreateScenarioStepDto[] Steps { get; set; }
    }
}
