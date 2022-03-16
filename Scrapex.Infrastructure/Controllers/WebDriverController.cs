using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Scrapex.Application.Configs;
using Scrapex.Application.Controllers;
using Scrapex.Application.Factories;
using Scrapex.Application.Views;
using SeleniumExtras.PageObjects;

namespace Scrapex.Infrastructure.Controllers
{
    public class WebDriverController : IWebDriverController
    {
        private readonly IWebDriver _driver;
        private readonly ILogger _logger;
        private readonly IConfig _config;
        private bool _isBusy { get; set; }


        public WebDriverController(
            IFactory<IWebDriver> driverFactory, 
            ILogger<WebDriverController> logger,
            IConfig config)
        {
            _driver = driverFactory.Create();
            _logger = logger;
            _config = config;
        }

        public Task<T> SwitchToView<T>() where T : IPageObject
        {
            // todo
            return new Task<T>(() => PageFactory.InitElements<T>(_driver));
        }
    }
}
