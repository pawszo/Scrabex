namespace Scrapex.Application.Services
{
    public interface IMediaService
    {
        bool TryGetBlobBytes(string path, out byte[] bytes);
    }
}
