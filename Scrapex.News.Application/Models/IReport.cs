using Scrapex.Domain.Models;

namespace Scrapex.News.Application.Models
{
    public interface IReport
    {
        ulong Id { get; set; }
        string ExternalId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ObtainedDate { get; set; }
        IEnumerable<string> Tags { get; set; }
        string Author { get; set; }
        string Title { get; set; }
        IEnumerable<IReaction> Reactions { get; set; }
        IEnumerable<ISection> Sections { get; set; }
        IEnumerable<IMedia> GetAllMedia();
        IEnumerable<T> GetAllMedia<T>() where T : IMedia;
    }
}
