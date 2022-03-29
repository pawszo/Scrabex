using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Dtos
{
    public class ScenarioDto
    {
        public int ScenarioId { get; set; }
        public Guid ScenarioGuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<ScenarioComponent> Components { get; set; }
        public IEnumerable<ScenarioStep> Steps { get; set; }
    }
}
