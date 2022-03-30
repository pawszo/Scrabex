using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class UpdateScenarioStepDto : CreateScenarioStepDto, IEntity
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public int AuthorId { get; set; }
    }
}