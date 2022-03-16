using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Scrapex.Application.Configs;
using Scrapex.Application.Factories;
using Scrapex.Domain.Enums;

namespace Scrapex.Infrastructure.Factories
{
    public class WebDriverFactory : IFactory<IWebDriver>
    {
        private readonly IConfig _config;

        public WebDriverFactory(IConfig config)
        {
            _config = config;
        }

        public IWebDriver Create()
        {
            switch(_config.WebDriver)
            {
                case WebDriverType.Chrome:
                    {
                        ChromeOptions options = new ChromeOptions
                        {
                            MinidumpPath = _config.MinidumpPath
                            //add options here
                        };

                        return new ChromeDriver(options);
                    }

                case WebDriverType.FireFox:
                    {
                        throw new NotImplementedException();
                    }

                default:
                    throw new NotImplementedException();

            }
        }
    }
}
