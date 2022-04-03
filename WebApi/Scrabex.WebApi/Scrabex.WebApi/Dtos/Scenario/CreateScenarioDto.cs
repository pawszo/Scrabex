using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class CreateScenarioDto
    {
        [SwaggerSchema(ReadOnly = true, Description = "Read-only")]
        public int AuthorId { get; set; }

        [SwaggerSchema(Description = "Components used to navigate in scenario scene")]
        public CreateScenarioComponentDto[] Components { get; set; }

        [SwaggerSchema(Description = "Steps to take sequentially in a scenario to complete a run")]
        public CreateScenarioStepDto[] Steps { get; set; }
    }
}
