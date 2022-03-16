using Scrapex.Application.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapex.Application.Controllers
{
    public interface IWebDriverController
    {
        Task<T> SwitchToView<T>() where T : IPageObject;
    }
}
