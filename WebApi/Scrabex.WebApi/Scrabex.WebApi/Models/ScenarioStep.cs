using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [JsonObject]
    [Table("ScenarioSteps")]
    public class ScenarioStep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StepId { get; set; }
        public int Order { get; set; }
        public string Action { get; set; }
        public int AuthorId { get; set; }
    }
}
