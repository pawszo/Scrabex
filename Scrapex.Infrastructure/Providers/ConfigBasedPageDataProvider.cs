using Scrapex.Application.Configs;
using Scrapex.Application.Providers;
using Scrapex.Application.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapex.Infrastructure.Providers
{
    public class ConfigBasedPageDataProvider : IPageDataProvider
    {
        private readonly IPageConfig _pageConfig;
        public ConfigBasedPageDataProvider(IPageConfig pageConfig)
        {
            _pageConfig = pageConfig;
        }

        public string GetPathForPage<T>() where T : IPageObject
        {
            throw new NotImplementedException();
        }
    }
}
