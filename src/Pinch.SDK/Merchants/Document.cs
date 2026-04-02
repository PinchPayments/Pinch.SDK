namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Represents a document associated with a merchant.
    /// </summary>
    /// <remarks>
    /// This class is used to store metadata about merchant documents, including their identifier, 
    /// type classification, and filename. It serves as a data model for document management operations.
    /// </remarks>
    public class Document
    {
        /// <summary>
        /// Gets or sets the unique identifier for the document.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the document (e.g., invoice, receipt, license).
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the filename of the document.
        /// </summary>
        public string Filename { get; set; }
    }
}
