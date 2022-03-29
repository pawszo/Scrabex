using Newtonsoft.Json;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class ScenarioStepDto
    {
        public int StepId { get; set; }
        public int Order { get; set; }
        public string Action { get; set; }
        public int AuthorId { get; set; }
    }
}
