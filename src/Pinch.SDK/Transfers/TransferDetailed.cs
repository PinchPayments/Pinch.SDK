using System;
using System.Collections.Generic;

namespace Pinch.SDK.Transfers
{
    /// <summary>
    /// Represents detailed information about a transfer transaction.
    /// </summary>
    public class TransferDetailed
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transfer.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the statement reference for the transfer.
        /// </summary>
        public string StatementReference { get; set; }
        
        /// <summary>
        /// Gets or sets the date when the transfer was executed.
        /// </summary>
        public DateTime TransferDate { get; set; }
        
        /// <summary>
        /// Gets or sets the transfer amount in cents.
        /// </summary>
        public long Amount { get; set; }
        
        /// <summary>
        /// Gets or sets the currency code for the transfer (e.g., "AUD", "USD").
        /// </summary>
        public string Currency { get; set; }
        
        /// <summary>
        /// Gets or sets the total fees associated with the transfer in cents.
        /// </summary>
        public long TotalFees { get; set; }
        
        /// <summary>
        /// Gets or sets the tax amount included in the transfer in cents.
        /// </summary>
        public long IncludedTax { get; set; }
        
        /// <summary>
        /// Gets or sets the tax rate applied to the transfer.
        /// </summary>
        public decimal TaxRate { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the account receiving the transfer.
        /// </summary>
        public string AccountName { get; set; }
        
        /// <summary>
        /// Gets or sets the account number receiving the transfer.
        /// </summary>
        public string AccountNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the Bank-State-Branch (BSB) code for the receiving account.
        /// </summary>
        public string Bsb { get; set; }
        
        /// <summary>
        /// Gets or sets the reference description for the transfer.
        /// </summary>
        public string Reference { get; set; }
        
        /// <summary>
        /// Gets or sets the current status of the transfer.
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Gets or sets the type of transfer.
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the transfer is gross billed.
        /// </summary>
        public bool IsGrossBilled { get; set; }

        /// <summary>
        /// Gets or sets the collection of summary items associated with the transfer.
        /// </summary>
        public IEnumerable<TransferSummaryItem> Summary { get; set; } = new List<TransferSummaryItem>();
    }
}
