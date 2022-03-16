using OpenQA.Selenium;
using Scrapex.Application.Views;
using SeleniumExtras.PageObjects;

namespace Scrapex.POM.Models
{
    public class WpNewsHomePage : IPageObject
    {
        private readonly IWebDriver _driver;

        public WpNewsHomePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        [FindsBy(How.XPath, @"//*[contains(@class, ""sectionsMenu"")]")]
        public IWebElement[] Categories { get; set; } 
    }
}
