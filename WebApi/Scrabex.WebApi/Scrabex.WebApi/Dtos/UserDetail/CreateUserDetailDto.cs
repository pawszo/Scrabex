using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class CreateUserDetailDto
    {
        [SwaggerRequestBody(Required = false, Description = "Read-only")]
        public int UserId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [SwaggerRequestBody(Required = true, Description = "5 or more characters. Must be unique")]
        public string Login { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [SwaggerRequestBody(Required = true, Description = "10 or more characters. Must contain letters, digits and special characters")]
        public string Password { get; set; }

        [SwaggerRequestBody(Required = true, Description = "Must be a valid email address")]
        public string Email { get; set; }

    }
}
