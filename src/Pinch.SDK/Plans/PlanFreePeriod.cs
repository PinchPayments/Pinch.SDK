namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Represents a free period configuration for a subscription plan.
    /// Defines when a free period starts and its duration using offset and interval values.
    /// </summary>
    public class PlanFreePeriod
    {
        /// <summary>
        /// Gets or sets the number of intervals to offset from the start of the subscription before the free period begins.
        /// </summary>
        public int StartDateOffset { get; set; }
        
        /// <summary>
        /// Gets or sets the interval type for the start date offset (e.g., "days", "weeks", "months").
        /// </summary>
        public string StartDateInterval { get; set; }
        
        /// <summary>
        /// Gets or sets the duration of the free period in the specified interval units.
        /// </summary>
        public int DurationOffset { get; set; }
        
        /// <summary>
        /// Gets or sets the interval type for the duration (e.g., "days", "weeks", "months").
        /// </summary>
        public string DurationInterval { get; set; }
        
        /// <summary>
        /// Gets or sets additional metadata associated with the free period.
        /// </summary>
        public string Metadata { get; set; }
    }
}