using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class CreateUserDetailDto
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Login { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Password { get; set; }

        public int UserId { get; set; }
    }
}
