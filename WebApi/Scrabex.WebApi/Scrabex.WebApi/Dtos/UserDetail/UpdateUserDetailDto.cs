using Newtonsoft.Json;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class UpdateUserDetailDto : CreateUserDetailDto, IEntity
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
    }
}
