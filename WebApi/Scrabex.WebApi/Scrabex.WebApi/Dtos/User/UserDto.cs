using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class UserDto : EntityBase
    {
        [SwaggerSchema(ReadOnly = true)]
        public override int Id { get; set; }
        public string UserTitle { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CreatedAt { get; set; }
        public string CountryCode { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public bool Confirmed { get; set; }
        public UserDetailDto Details { get; set; }
    }
}
