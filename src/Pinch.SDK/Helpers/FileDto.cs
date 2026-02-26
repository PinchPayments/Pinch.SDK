using System.IO;

namespace Pinch.SDK.Helpers
{
    /// <summary>
    /// Represents a file data transfer object containing file content and metadata.
    /// </summary>
    public class FileDto
    {
        /// <summary>
        /// Gets or sets the stream containing the file content.
        /// </summary>
        public Stream Stream { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string Filename { get; set; }
        
        /// <summary>
        /// Gets or sets the MIME content type of the file.
        /// </summary>
        public string ContentType { get; set; }
    }
}