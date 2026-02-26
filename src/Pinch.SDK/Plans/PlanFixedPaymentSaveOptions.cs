using System.Collections.Generic;

namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Options for saving a fixed payment within a plan.
    /// </summary>
    /// <remarks>
    /// This class represents the configuration options when creating or updating a fixed payment schedule
    /// for a plan. It allows specifying either a fixed amount or a percentage-based amount, along with
    /// scheduling details and error handling options.
    /// </remarks>
    public class PlanFixedPaymentSaveOptions
    {
        /// <summary>
        /// Gets or sets the fixed payment amount in cents.
        /// </summary>
        /// <remarks>
        /// Specify either <see cref="AmountInCents"/> or <see cref="AmountPercentage"/>, but not both.
        /// </remarks>
        public long? AmountInCents { get; set; }

        /// <summary>
        /// Gets or sets the fixed payment amount as a percentage.
        /// </summary>
        /// <remarks>
        /// Specify either <see cref="AmountInCents"/> or <see cref="AmountPercentage"/>, but not both.
        /// </remarks>
        public decimal? AmountPercentage { get; set; }

        /// <summary>
        /// Gets or sets the description of the fixed payment.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the offset from the plan's start date for scheduling the payment.
        /// </summary>
        /// <remarks>
        /// Used in conjunction with <see cref="ScheduledDateInterval"/> to determine when the payment should occur.
        /// For example, an offset of 14 with an interval of "days" would schedule the payment 14 days from the start date.
        /// </remarks>
        public int ScheduledDateOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval unit for the scheduled date offset.
        /// </summary>
        /// <remarks>
        /// Common values include "days", "weeks", or "months". Used in conjunction with <see cref="ScheduledDateOffset"/>.
        /// </remarks>
        public string ScheduledDateInterval { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plan should be cancelled if this fixed payment fails.
        /// </summary>
        public bool CancelPlanOnFailure { get; set; }

        /// <summary>
        /// Gets or sets custom metadata associated with the fixed payment.
        /// </summary>
        /// <remarks>
        /// This can be used to store application-specific data related to the payment.
        /// </remarks>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets a list of errors that occurred during validation or processing.
        /// </summary>
        /// <remarks>
        /// This is typically populated by the API in response to a request with validation errors.
        /// </remarks>
        public List<ApiError> Errors { get; set; }
    }
}