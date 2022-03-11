using System.IO;

namespace Pinch.SDK.Merchants
{
    public class DocumentUploadOptions
    {
        /// <summary>
        /// When a document is related to a specific contact, supply the value here. Only required for Identity Documents.
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// The type of file being uploaded. See API docs for available values.
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// The document itself
        /// </summary>
        public Stream File { get; set; }

        /// <summary>
        /// The filename for display purposes
        /// </summary>
        public string Filename { get; set; }
    }
}