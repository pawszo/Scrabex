using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class ScenarioStepDto : EntityBase
    {
        [SwaggerSchema(ReadOnly = true)]
        public override int Id { get; set; }
        public int ScenarioId { get; set; }
        public int Order { get; set; }
        public string Action { get; set; }
        public int AuthorId { get; set; }
    }
}
