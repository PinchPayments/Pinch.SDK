using System.Collections.Generic;

namespace Pinch.SDK.Fees
{
    /// <summary>
    /// Options for calculating fees associated with a payment transaction.
    /// </summary>
    public class FeesCalculateOptions
    {
        /// <summary>
        /// Gets or sets the type of payment source.
        /// </summary>
        public string SourceType { get; set; }
        
        /// <summary>
        /// Gets or sets the payment source token.
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// Gets or sets the unique identifier of the payment source.
        /// </summary>
        public string SourceId { get; set; }
        
        /// <summary>
        /// Gets or sets the transaction amount in the smallest currency unit (e.g., cents).
        /// </summary>
        public long Amount { get; set; }
        
        /// <summary>
        /// Gets or sets the application fee amount in the smallest currency unit (e.g., cents).
        /// </summary>
        public long ApplicationFee { get; set; }
        
        /// <summary>
        /// Gets or sets the three-letter ISO currency code (e.g., "USD", "AUD").
        /// </summary>
        public string Currency { get; set; }
        
        /// <summary>
        /// Gets or sets the list of surcharge types to apply to the transaction.
        /// </summary>
        public List<string> Surcharge { get; set; } = new List<string>();
    }
}
