using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapex.Application.Services
{
    public interface ISourceService
    {
        bool TryConnect();
        bool TryDisconnect();
        bool TryAuthorize();
        bool TryLoadPage();

    }
}
