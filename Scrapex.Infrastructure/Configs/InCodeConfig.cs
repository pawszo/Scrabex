using Scrapex.Application.Configs;
using Scrapex.Domain.Enums;

namespace Scrapex.Infrastructure.Configs
{
    public class InCodeConfig : IConfig
    {
        public WebDriverType WebDriver { get; }

        public string Url { get; }

        public string WorkDirectory { get; }
        public string MinidumpPath => Path.Combine(WorkDirectory, @"\minidump");

        public InCodeConfig()
        {
            WebDriver = WebDriverType.Chrome;
            Url = @"https://wiadomosci.wp.pl/";
            WorkDirectory = @"C:\dev\tools\Scrappings";
        }
    }
}
