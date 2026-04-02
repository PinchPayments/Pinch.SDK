using System;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Payments
{
    /// <summary>
    /// Represents the result of a bank payment transaction.
    /// </summary>
    /// <remarks>
    /// This class encapsulates the details of a payment that has been processed through a banking system,
    /// including transaction information, status, and dates. It is used to communicate payment outcomes
    /// from the payment processing system to the application.
    /// </remarks>
    public class BankResultPayment
    {
        /// <summary>
        /// Gets or sets the unique identifier for this bank payment result.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the payment attempt associated with this result.
        /// </summary>
        public string AttemptId { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount in cents.
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the description of the transaction.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the transaction provider or financial institution that processed the payment.
        /// </summary>
        public string TransactionProvider { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the transaction was processed.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the current status of the payment (e.g., "Completed", "Pending", "Failed").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the estimated date when the funds will be transferred to the merchant.
        /// </summary>
        public DateTime EstimatedTransferDate { get; set; }

        /// <summary>
        /// Gets or sets the payer details associated with this payment.
        /// </summary>
        public Payer Payer { get; set; }

        /// <summary>
        /// Gets or sets the dishonour details if the payment was dishonored; otherwise <c>null</c>.
        /// </summary>
        public Dishonour Dishonour { get; set; }
    }
}
