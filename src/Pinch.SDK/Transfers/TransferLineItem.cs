using System;

namespace Pinch.SDK.Transfers
{
    /// <summary>
    /// Represents a line item within a transfer, detailing individual transactions or adjustments.
    /// </summary>
    public class TransferLineItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transfer line item.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the type of the line item (e.g., payment, refund, adjustment).
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Gets or sets the gross amount in the smallest currency unit (e.g., cents).
        /// </summary>
        public int Gross { get; set; }
        
        /// <summary>
        /// Gets or sets the fees amount in the smallest currency unit (e.g., cents).
        /// </summary>
        public int Fees { get; set; }
        
        /// <summary>
        /// Gets or sets a description of the line item.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time when the transaction occurred.
        /// </summary>
        public DateTime TransactionDate { get; set; }
        
        /// <summary>
        /// Gets or sets the total amount in the smallest currency unit (e.g., cents).
        /// </summary>
        public int Total { get; set; }
    }
}
