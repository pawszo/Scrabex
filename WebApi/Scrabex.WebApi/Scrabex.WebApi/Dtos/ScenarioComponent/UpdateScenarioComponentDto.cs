using Newtonsoft.Json;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class UpdateScenarioComponentDto : CreateScenarioComponentDto, IEntity
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
    }
}
