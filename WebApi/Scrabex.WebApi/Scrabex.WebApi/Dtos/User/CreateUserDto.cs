using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class CreateUserDto
    {
        public string UserTitle { get; set; }
        public string CountryCode { get; set; }
        public CreateUserDetailDto Details { get; set; }
    }
}