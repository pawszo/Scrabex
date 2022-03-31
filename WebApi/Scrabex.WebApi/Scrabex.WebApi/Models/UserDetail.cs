using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{ 
    [Table("UserDetails")]
    public class UserDetail : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string Login { get; set; }
        
        /// <summary>
        /// MD5 hashed password
        /// </summary>
        public string Password { get; set; }
        public string Email { get; set; }
        public bool ForgotPassword { get; set; }
        public DateTime LastUpdate { get; set; }

        [ForeignKey("User.Id")]
        public int UserId { get; set; }
    }
}
