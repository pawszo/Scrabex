using Scrapex.Domain.Enums;

namespace Scrapex.Application.Configs
{
    public interface IConfig
    {
        WebDriverType WebDriver { get; }
        string Url { get; }
        string WorkDirectory { get; }
        string MinidumpPath { get; }

    }
}
