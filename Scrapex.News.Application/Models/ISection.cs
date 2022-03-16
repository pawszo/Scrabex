using Scrapex.Domain.Models;

namespace Scrapex.News.Application.Models
{
    public interface ISection
    {
        string Header { get; set; }
        string Content { get; set; }
        IEnumerable<IMedia> MediaItems { get; set; }
        IEnumerable<ISection> SubSections { get; set; }
    }
}