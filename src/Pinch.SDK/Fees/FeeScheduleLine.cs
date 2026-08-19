namespace Pinch.SDK.Fees
{
    /// <summary>
    /// Represents a fee schedule line containing fee information for different zones and schemes.
    /// </summary>
    public class FeeScheduleLine
    {
        /// <summary>
        /// Gets or sets the destination zone.
        /// </summary>
        public string DestinationZone { get; set; }
        
        /// <summary>
        /// Gets or sets the origin zone.
        /// </summary>
        public string OriginZone { get; set; }
        
        /// <summary>
        /// Gets or sets the fee scheme.
        /// </summary>
        public string FeeScheme { get; set; }
        
        /// <summary>
        /// Gets or sets the percentage fee.
        /// </summary>
        public decimal PercentageFee { get; set; }
        
        /// <summary>
        /// Gets or sets the fixed fee.
        /// </summary>
        public long FixedFee { get; set; }
        
        /// <summary>
        /// Gets or sets the cap amount.
        /// </summary>
        public long Cap { get; set; }
        
        /// <summary>
        /// Gets or sets the dishonour fee.
        /// </summary>
        public long DishonourFee { get; set; }
        
        /// <summary>
        /// Gets or sets the dispute fee.
        /// </summary>
        public long DisputeFee { get; set; }
    }
}