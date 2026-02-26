using System;
using System.Collections.Generic;

namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Represents the compliance information and status for a merchant.
    /// </summary>
    /// <remarks>
    /// This class contains merchant compliance details including verification statuses, 
    /// notes from various parties, feature enablement flags, and associated compliance documents.
    /// </remarks>
    public class Compliance
    {
        /// <summary>
        /// Gets or sets notes provided by the merchant.
        /// </summary>
        public string MerchantNotes { get; set; }

        /// <summary>
        /// Gets or sets validation errors related to merchant properties.
        /// </summary>
        public string PropertyErrors { get; set; }

        /// <summary>
        /// Gets or sets notes provided by the compliance officer.
        /// </summary>
        public string ComplianceOfficerNotes { get; set; }

        /// <summary>
        /// Gets or sets the current compliance status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the compliance submission was made.
        /// </summary>
        private DateTimeOffset SubmissionDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the compliance decision was made, if applicable.
        /// </summary>
        private DateTimeOffset? DecisionDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the merchant is enabled for live transactions.
        /// </summary>
        public bool LiveEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the merchant is enabled to process transactions.
        /// </summary>
        public bool TransactionsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the merchant is enabled to receive settlements.
        /// </summary>
        public bool SettlementsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the verification status of submitted documents.
        /// </summary>
        public string DocumentVerificationStatus { get; set; }

        /// <summary>
        /// Gets or sets the verification status of the merchant's bank account.
        /// </summary>
        public string BankAccountVerificationStatus { get; set; }

        /// <summary>
        /// Gets or sets the collection of contact compliance records associated with this merchant.
        /// </summary>
        public IList<ContactCompliance> ContactCompliances { get; set; } = new List<ContactCompliance>();

        /// <summary>
        /// Gets or sets the collection of documents submitted for compliance verification.
        /// </summary>
        public IList<Document> Documents { get; set; } = new List<Document>();
    }
}
