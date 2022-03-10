using System.IO;

namespace Pinch.SDK.Merchants
{
    public class DocumentUploadOptions
    {
        /// <summary>
        /// Optional
        /// </summary>
        public string ContactId { get; set; }
        public Stream File { get; set; }
        // Document options
        public DocumentType DocumentType { get; set; }
    }
}