using Newtonsoft.Json;
using Scrabex.WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class UserDetailDto : EntityBase
    {
        public override int Id { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public bool ForgotPassword { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime LastUpdate { get; set; }
    }
}
