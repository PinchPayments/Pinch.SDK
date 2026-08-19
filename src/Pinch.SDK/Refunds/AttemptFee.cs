namespace Pinch.SDK.Refunds
{
    /// <summary>
    /// Represents fee details associated with a refund attempt, including base and converted amounts.
    /// </summary>
    public class AttemptFee
    {
        /// <summary>
        /// Gets or sets the transaction fee amount in the original currency.
        /// </summary>
        public long TransactionFee { get; set; }

        /// <summary>
        /// Gets or sets the application fee amount in the original currency.
        /// </summary>
        public long ApplicationFee { get; set; }

        /// <summary>
        /// Gets or sets the total fee amount in the original currency.
        /// </summary>
        public long TotalFee { get; set; }

        /// <summary>
        /// Gets or sets the ISO currency code for the original amounts.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the tax rate applied to the fees.
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the converted transaction fee amount, if available.
        /// </summary>
        public long? ConvertedTransactionFee { get; set; }

        /// <summary>
        /// Gets or sets the converted application fee amount, if available.
        /// </summary>
        public long? ConvertedApplicationFee { get; set; }

        /// <summary>
        /// Gets or sets the converted total fee amount, if available.
        /// </summary>
        public long? ConvertedTotalFee { get; set; }

        /// <summary>
        /// Gets or sets the ISO currency code for the converted amounts.
        /// </summary>
        public string ConvertedCurrency { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate used to convert amounts, if available.
        /// </summary>
        public decimal? ConversionRate { get; set; }
    }
}