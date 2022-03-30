using Newtonsoft.Json;

namespace Scrabex.WebApi.Models
{
    [JsonObject]
    public abstract class EntityBase : IEntity
    {
        public abstract int Id { get; set; }

        public EntityBase() { }
    }
}
