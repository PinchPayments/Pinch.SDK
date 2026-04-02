namespace Pinch.SDK.Refunds
{
    /// <summary>
    /// Represents a refund transaction in the Pinch payment system.
    /// </summary>
    /// <remarks>
    /// This class contains all relevant information about a refund, including amounts,
    /// dates, status, and conversion details if the refund was converted to a different currency.
    /// </remarks>
    public class Refund
    {
        /// <summary>
        /// Gets or sets the unique identifier for the refund.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the refund amount in the smallest currency unit (e.g., cents for USD).
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the ISO 4217 currency code of the refund amount.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the refund processing fee charged for this refund in the smallest currency unit.
        /// </summary>
        public long RefundFeeCharged { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the refund was requested.
        /// </summary>
        public string RequestedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the refund was completed.
        /// </summary>
        public string CompletedDate { get; set; }

        /// <summary>
        /// Gets or sets the reason for issuing the refund.
        /// </summary>
        public string ReasonForRefund { get; set; }

        /// <summary>
        /// Gets or sets additional notes or comments associated with the refund.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the refund amount converted to another currency, if applicable.
        /// </summary>
        public long? ConvertedAmount { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate used to convert the refund amount to another currency.
        /// </summary>
        public decimal? ConversionRate { get; set; }

        /// <summary>
        /// Gets or sets the ISO 4217 currency code of the converted amount.
        /// </summary>
        public string ConvertedCurrency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the amount is a gross amount (before fees).
        /// </summary>
        public bool IsGross { get; set; }

        /// <summary>
        /// Gets or sets the current status of the refund (e.g., pending, completed, failed).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated transfer transaction.
        /// </summary>
        public string TransferId { get; set; }

        /// <summary>
        /// Gets or sets the details of fees that were refunded as part of this refund transaction.
        /// </summary>
        public AttemptFee RefundedFees { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the original payment being refunded.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Gets or sets the idempotency key, a unique token generated for this refund transaction.
        /// </summary>
        public string IdempotencyKey { get; set; }
    }
}