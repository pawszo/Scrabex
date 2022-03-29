using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [JsonObject]
    [Table("UserDetails")]
    public class UserDetail
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool ForgotPassword { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
