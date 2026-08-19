using System.Collections.Generic;

namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Represents the options for creating or updating a free period configuration for a subscription plan.
    /// A free period allows subscribers to access the plan without charges for a specified duration.
    /// </summary>
    public class PlanFreePeriodSaveOptions
    {
        /// <summary>
        /// Gets or sets the number of intervals to offset from the start of the subscription before the free period begins.
        /// For example, if set to 1 with StartDateInterval of "months", the free period starts 1 month after subscription creation.
        /// </summary>
        public int StartDateOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval type for the start date offset.
        /// Typical values include "days", "weeks", or "months".
        /// </summary>
        public string StartDateInterval { get; set; }

        /// <summary>
        /// Gets or sets the duration of the free period in the specified interval units.
        /// For example, if set to 7 with DurationInterval of "days", the free period lasts 7 days.
        /// </summary>
        public int DurationOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval type for the duration.
        /// Typical values include "days", "weeks", or "months".
        /// </summary>
        public string DurationInterval { get; set; }

        /// <summary>
        /// Gets or sets additional metadata associated with the free period.
        /// Can be used to store custom information in a structured format (e.g., JSON string).
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the list of API validation errors that occurred during the save operation.
        /// This property is populated when the API request fails validation.
        /// </summary>
        public List<ApiError> Errors { get; set; }
    }
}