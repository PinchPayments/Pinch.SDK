using System;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Agreements
{
    /// <summary>
    /// Represents detailed information about an agreement.
    /// </summary>
    public class AgreementDetailed
    {
        /// <summary>
        /// Gets or sets the unique identifier for the agreement.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the surname or company name.
        /// </summary>
        public string SurnameOrCompanyName { get; set; }
        
        /// <summary>
        /// Gets or sets the given names or ABN (Australian Business Number).
        /// </summary>
        public string GivenNamesOrAbn { get; set; }
        
        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        public string AccountName { get; set; }
        
        /// <summary>
        /// Gets or sets the account BSB (Bank State Branch).
        /// </summary>
        public string AccountBsb { get; set; }
        
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public string AccountNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the signatory name.
        /// </summary>
        public string SignatoryName { get; set; }
        
        /// <summary>
        /// Gets or sets the first line of the signatory address.
        /// </summary>
        public string SignatoryAddress1 { get; set; }
        
        /// <summary>
        /// Gets or sets the second line of the signatory address.
        /// </summary>
        public string SignatoryAddress2 { get; set; }
        
        /// <summary>
        /// Gets or sets the signatory email address.
        /// </summary>
        public string SignatoryEmail { get; set; }

        /// <summary>
        /// Gets or sets the agreement date in UTC.
        /// </summary>
        public DateTime AgreementDateUtc { get; set; }
        
        /// <summary>
        /// Gets or sets the confirmed date in UTC.
        /// </summary>
        public DateTime? ConfirmedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the anonymous view token.
        /// </summary>
        public string AnonymousViewToken { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the PDF has been generated.
        /// </summary>
        public bool IsPdfGenerated { get; set; }

        /// <summary>
        /// Gets or sets the payer associated with this agreement.
        /// </summary>
        public Payer Payer { get; set; }
    }
}
