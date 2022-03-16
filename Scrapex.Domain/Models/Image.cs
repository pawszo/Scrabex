namespace Scrapex.Domain.Models
{
    public class Photo : IMediaType
    {
        public byte[] Bytes { get; }

        public Photo(byte[] bytes)
        {
            Bytes = bytes;
        }
    }
}
