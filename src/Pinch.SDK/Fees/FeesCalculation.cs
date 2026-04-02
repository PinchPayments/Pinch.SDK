using Pinch.SDK.Payments;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Fees
{
    /// <summary>
    /// Represents the result of a fees calculation, including amounts, fees, and associated payment details.
    /// </summary>
    public class FeesCalculation
    {
        /// <summary>
        /// Gets or sets the total payment amount in the smallest currency unit (e.g., cents).
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the payment amount (e.g., "AUD", "USD").
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the net amount after fees have been applied, in the smallest currency unit.
        /// </summary>
        public long NetAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the fees are surcharged to the payer.
        /// </summary>
        public bool IsSurcharged { get; set; }

        /// <summary>
        /// Gets or sets the converted payment amount in the smallest currency unit, if currency conversion was applied; otherwise, null.
        /// </summary>
        public long? ConvertedAmount { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the converted amount, if currency conversion was applied.
        /// </summary>
        public string ConvertedCurrency { get; set; }

        /// <summary>
        /// Gets or sets the converted net amount after fees in the smallest currency unit, if currency conversion was applied; otherwise, null.
        /// </summary>
        public long? ConvertedNetAmount { get; set; }

        /// <summary>
        /// Gets or sets the detailed breakdown of fees applied to this payment.
        /// </summary>
        public PaymentFees Fees { get; set; }

        /// <summary>
        /// Gets or sets the payment source (e.g., bank account or card) used for this transaction.
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// Gets or sets the fee schedule line that was used to calculate the fees for this transaction.
        /// </summary>
        public FeeScheduleLine FeeSchedule { get; set; }
    }
}
