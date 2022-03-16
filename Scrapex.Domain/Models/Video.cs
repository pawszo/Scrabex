namespace Scrapex.Domain.Models
{
    public class Video : IMediaType
    {
        public Video(byte[] bytes)
        {
            Bytes = bytes;
        }
        public byte[] Bytes { get; }
    }
}
