using Scrapex.Application.Configs;
using Scrapex.Application.Views;

namespace Scrapex.Application.Providers
{
    public interface IPageDataProvider
    {
        string GetPathForPage<T>() where T : IPageObject;
    }
}
