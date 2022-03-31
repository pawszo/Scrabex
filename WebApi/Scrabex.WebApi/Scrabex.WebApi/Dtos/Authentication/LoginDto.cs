using Newtonsoft.Json;

namespace Scrabex.WebApi.Dtos
{
    [JsonObject]
    public class LoginDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool ForgotPassword { get; set; }
    }
}
