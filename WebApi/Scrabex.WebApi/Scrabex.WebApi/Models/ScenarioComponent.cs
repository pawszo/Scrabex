using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrabex.WebApi.Models
{
    [JsonObject]
    [Table("ScenarioComponents")]
    public class ScenarioComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public int ScenarioId  { get; set; }
    }
}
