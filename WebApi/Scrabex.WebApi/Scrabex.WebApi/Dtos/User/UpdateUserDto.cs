using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos.User
{
    [JsonObject]
    public class UpdateUserDto : CreateUserDto, IEntity
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public bool Confirmed { get; set; }
        public new UpdateUserDetailDto Details { get; set; }

    }
}
