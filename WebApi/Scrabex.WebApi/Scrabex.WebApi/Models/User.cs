using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [JsonObject]
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CountryCode { get; set; }
        public bool Confirmed { get; set; }
    }
}
