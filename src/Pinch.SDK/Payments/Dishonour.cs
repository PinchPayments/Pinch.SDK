using System;

namespace Pinch.SDK.Payments
{
    /// <summary>
    /// Represents a dishonoured payment transaction.
    /// A dishonour occurs when a payment attempt is rejected or fails to process, 
    /// typically due to insufficient funds, invalid account, or other payment processing issues.
    /// </summary>`
    public class Dishonour
    {
        /// <summary>
        /// Gets or sets the type of dishonour.
        /// Indicates the specific reason or category for the payment dishonour.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the date when the dishonour occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the fees associated with the dishonoured payment.
        /// Typically includes dishonour or rejection fees charged by the financial institution.
        /// </summary>
        public long Fees { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the transfer associated with the dishonour.
        /// </summary>
        public string TransferId { get; set; }

        /// <summary>
        /// Gets or sets the expanded payment details associated with the dishonoured transaction.
        /// Contains comprehensive information about the payment that was dishonoured.
        /// </summary>
        public PaymentExpanded Payment { get; set; }
    }
}
