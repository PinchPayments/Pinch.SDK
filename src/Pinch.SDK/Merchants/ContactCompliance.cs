using System.Collections.Generic;

namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Represents the compliance status and verification information for a contact within the Pinch SDK.
    /// </summary>
    /// <remarks>
    /// This class tracks the various compliance and verification states of a contact, including document,
    /// identity, email, and phone verification statuses. It provides an overall compliance status and
    /// maintains a collection of associated documents used for verification purposes.
    /// </remarks>
    public class ContactCompliance
    {
        /// <summary>
        /// Gets or sets the unique identifier for the contact.
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// Gets or sets the overall compliance status of the contact.
        /// </summary>
        /// <remarks>
        /// This represents the aggregate compliance status across all verification checks.
        /// </remarks>
        public string OverallStatus { get; set; }

        /// <summary>
        /// Gets or sets the document verification status of the contact.
        /// </summary>
        /// <remarks>
        /// Indicates the status of document-based verification checks for the contact.
        /// </remarks>
        public string DocumentVerificationStatus { get; set; }

        /// <summary>
        /// Gets or sets the identity verification status of the contact.
        /// </summary>
        /// <remarks>
        /// Indicates the status of identity verification checks for the contact.
        /// </remarks>
        public string IdentityVerificationStatus { get; set; }

        /// <summary>
        /// Gets or sets the email verification status of the contact.
        /// </summary>
        /// <remarks>
        /// Indicates whether the contact's email address has been verified.
        /// </remarks>
        public string EmailVerificationStatus { get; set; }

        /// <summary>
        /// Gets or sets the phone verification status of the contact.
        /// </summary>
        /// <remarks>
        /// Indicates whether the contact's phone number has been verified.
        /// </remarks>
        public string PhoneVerificationStatus { get; set; }

        /// <summary>
        /// Gets or sets the collection of documents associated with the contact's compliance verification.
        /// </summary>
        /// <remarks>
        /// This list contains all documents submitted or required for the contact's compliance and
        /// verification processes. The list is initialized as an empty collection by default.
        /// </remarks>
        public IList<Document> Documents { get; set; } = new List<Document>();
    }
}
