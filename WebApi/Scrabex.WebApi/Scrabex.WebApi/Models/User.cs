using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [Table("Users")]
    public class User : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string UserTitle { get; set; }        
        public DateTime CreatedAt { get; set; }
        public string CountryCode { get; set; }
        public bool Confirmed { get; set; }
    }
}
