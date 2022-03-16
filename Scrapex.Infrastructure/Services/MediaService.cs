using OpenQA.Selenium;
using Microsoft.Extensions.Logging;
using Scrapex.Domain.Scripts;
using Scrapex.Application.Services;
using Scrapex.Application.Factories;

namespace Scrapex.Infrastructure
{
    public class MediaService : IMediaService
    {
        private readonly IWebDriver _webDriver;
        private readonly ILogger _logger;

        private IJavaScriptExecutor _jsExecutor => _webDriver as IJavaScriptExecutor;

        public MediaService(IFactory<IWebDriver> webDriverFactory, ILogger<MediaService> logger)
        {
            _webDriver = webDriverFactory.Create();
            _logger = logger;
        }

        public bool TryGetBlobBytes(string path, out byte[] bytes)
        {
            bytes = Array.Empty<byte>();
            _webDriver.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(0, 1, 0);
            try
            {
                var result = (string)_jsExecutor.ExecuteAsyncScript(JsScripts.LoadBlobContent, path);
                bytes = Convert.FromBase64String(result);
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message + "\n" + ex.StackTrace);
                return false;
            }
            
        }
    }
}
