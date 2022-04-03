using Microsoft.EntityFrameworkCore;
using Scrabex.WebApi.Models;

namespace Scrabex.WebApi.Contexts
{
    public class ScenarioContext : DbContext
    {
        public ScenarioContext(DbContextOptions<ScenarioContext> options) : base(options)
        {
        }

        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<ScenarioComponent> Components { get; set; }
        public DbSet<ScenarioStep> Steps { get; set; }
    }
}
