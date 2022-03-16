using System.Net;

namespace Scrapex.Domain.Models
{
    public interface IWebActionResult : IActionResult
    {
        HttpStatusCode StatusCode { get; }
    }
}
