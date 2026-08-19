namespace Pinch.SDK.Subscriptions
{
    /// <summary>
    /// Represents a free period configuration for a subscription.
    /// Defines when the free period starts, its duration, and associated metadata.
    /// </summary>
    public class SubscriptionFreePeriod
    {
        /// <summary>
        /// Gets or sets the start date of the free period.
        /// </summary>
        public string StartDate { get; set; }
        
        /// <summary>
        /// Gets or sets the duration offset value for the free period.
        /// This value is used in conjunction with <see cref="DurationInterval"/> to determine the length of the free period.
        /// </summary>
        public int DurationOffset { get; set; }
        
        /// <summary>
        /// Gets or sets the duration interval unit for the free period (e.g., "days", "weeks", "months").
        /// This value is used in conjunction with <see cref="DurationOffset"/> to determine the length of the free period.
        /// </summary>
        public string DurationInterval { get; set; }
        
        /// <summary>
        /// Gets or sets optional metadata associated with the free period.
        /// </summary>
        public string Metadata { get; set; }
    }
}
