using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class UserDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        public string UserTitle { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CountryCode { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public bool Confirmed { get; set; }
        public UserDetailDto Details { get; set; }
    }
}
