using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class ScenarioComponentDto : EntityBase
    {
        [SwaggerSchema(ReadOnly = true)]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public int ScenarioId { get; set; }
    }
}
