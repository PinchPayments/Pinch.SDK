using System.IO;

namespace Pinch.SDK.Helpers
{
    public class FileDto
    {
        public Stream Stream { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
    }
}