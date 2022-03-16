namespace Scrapex.Domain.Models
{
    public class VideoMedia : IMedia<Video>
    {
        public int Size { get; }
        public ulong Length { get; }

        public string Path { get; }

        public string Title { get; }
        public Video Content { get; }

        IMediaType IMedia.Content => Content;

        public VideoMedia(string title, string path, ulong length, byte[] videoBytes)
        {
            Title = title;
            Path = path;
            Length = length;
            Content = new Video(videoBytes);
            Size = videoBytes.Length;
        }

        public byte[] ToByteArray() => Content.Bytes;
    }
}