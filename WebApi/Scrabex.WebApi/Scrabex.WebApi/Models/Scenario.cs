using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [Table("Scenarios")]
    public class Scenario : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid ScenarioGuid { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int AuthorId { get; set; }
    }

}
