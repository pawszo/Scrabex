using Newtonsoft.Json;

namespace Scrabex.WebApi.Dtos.Authentication
{
    [JsonObject]
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
