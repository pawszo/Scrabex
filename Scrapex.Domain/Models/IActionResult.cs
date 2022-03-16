namespace Scrapex.Domain.Models
{
    public interface IActionResult
    {
        bool Success { get; }
        string Error { get; }
    }
}
