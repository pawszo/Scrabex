using static System.Net.Mime.MediaTypeNames;

namespace Scrapex.Domain.Models
{
    public interface IMedia<T> : IMedia where T : IMediaType
    {
        byte[] ToByteArray();
        new T Content { get; }
        /// <summary>
        /// Total bytes
        /// </summary>
        int Size { get; }
        string Path { get; }
        string Title { get; }
    }

    public interface IMedia
    {
        IMediaType Content { get; }
    }
}
