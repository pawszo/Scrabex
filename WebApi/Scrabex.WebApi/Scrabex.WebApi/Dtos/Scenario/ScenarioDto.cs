using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class ScenarioDto : EntityBase
    {
        [SwaggerSchema(ReadOnly = true)]
        public override int Id { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public Guid ScenarioGuid { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CreatedAt { get; set; }
        public int AuthorId { get; set; }
        public ScenarioComponentDto[] Components { get; set; }
        public ScenarioStepDto[] Steps { get; set; }
    }
}
