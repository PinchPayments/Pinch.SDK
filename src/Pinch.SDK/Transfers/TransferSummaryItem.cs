namespace Pinch.SDK.Transfers
{
    /// <summary>
    /// Represents a summary of transfer information including amounts and counts.
    /// </summary>
    public class TransferSummaryItem
    {
        /// <summary>
        /// Gets or sets the name associated with the transfer summary.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the count of items included in the transfer.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the gross amount of the transfer in cents.
        /// </summary>
        public int Gross { get; set; }

        /// <summary>
        /// Gets or sets the fees amount of the transfer in cents.
        /// </summary>
        public int Fees { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the transfer in cents (typically Gross - Fees).
        /// </summary>
        public int Total { get; set; }
    }
}
