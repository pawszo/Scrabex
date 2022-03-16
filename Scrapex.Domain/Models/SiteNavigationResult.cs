using Scrapex.Domain.ExtensionMethods;
using System.Net;

namespace Scrapex.Domain.Models
{
    public class SiteNavigationResult : IWebActionResult
    {
        public bool Success { get; }

        public string Error { get; }

        public HttpStatusCode StatusCode { get; }

        public SiteNavigationResult(bool isSuccess, string error, int statusCode)
        {
            Success = isSuccess;
            Error = error;
            StatusCode = statusCode.TryParseToEnum<HttpStatusCode>(out var code) ? code : HttpStatusCode.NotFound;
        }
    }
}
