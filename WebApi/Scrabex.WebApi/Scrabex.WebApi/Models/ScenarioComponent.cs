using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [Table("ScenarioComponents")]
    public class ScenarioComponent : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public int ScenarioId  { get; set; }
    }
}
