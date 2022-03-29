using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [JsonObject]
    [Table("Scenarios")]
    public class Scenario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScenarioId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid ScenarioGuid { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int AuthorId { get; set; }
    }

}
