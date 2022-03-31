using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [Table("ScenarioSteps")]
    public class ScenarioStep : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public int Order { get; set; }
        public string Action { get; set; }
        public int ScenarioId { get; set; }
    }
}
