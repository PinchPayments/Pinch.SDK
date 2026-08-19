using System;

namespace Pinch.SDK.Payments
{
    /// <summary>
    /// Represents a payment settlement with associated fees and transfer information
    /// </summary>
    public class Settlement
    {
        /// <summary>
        /// The date this payment was settled
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// The total fees for this settlement
        /// </summary>
        public long Fees { get; set; }
        /// <summary>
        /// The Transfer ID for this settlement
        /// </summary>
        public string TransferId { get; set; }
    }
}
