using System.Collections.Generic;

namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Represents options for creating or updating a recurring payment configuration on a plan.
    /// </summary>
    public class PlanRecurringPaymentSaveOptions
    {
        /// <summary>
        /// Gets or sets the fixed amount in cents for the recurring payment.
        /// Mutually exclusive with <see cref="AmountPercentage"/>.
        /// </summary>
        public long? AmountInCents { get; set; }

        /// <summary>
        /// Gets or sets the percentage-based amount for the recurring payment.
        /// Mutually exclusive with <see cref="AmountInCents"/>.
        /// </summary>
        public decimal? AmountPercentage { get; set; }

        /// <summary>
        /// Gets or sets the description of the recurring payment.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the numeric offset for when the recurring payment should start.
        /// Used in conjunction with <see cref="StartDateInterval"/>.
        /// </summary>
        public int StartDateOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval type for the start date offset (e.g., "days", "weeks", "months").
        /// </summary>
        public string StartDateInterval { get; set; }

        /// <summary>
        /// Gets or sets the numeric value for how often the payment should recur.
        /// Used in conjunction with <see cref="FrequencyInterval"/>.
        /// </summary>
        public int FrequencyOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval type for the frequency (e.g., "days", "weeks", "months").
        /// </summary>
        public string FrequencyInterval { get; set; }

        /// <summary>
        /// Gets or sets the type of end condition for the recurring payment (e.g., "date", "count", "amount", "never").
        /// </summary>
        public string EndType { get; set; }

        /// <summary>
        /// Gets or sets the numeric offset for when the recurring payment should end.
        /// Used in conjunction with <see cref="EndDateInterval"/> when <see cref="EndType"/> is "date".
        /// </summary>
        public int? EndDateOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval type for the end date offset (e.g., "days", "weeks", "months").
        /// Used when <see cref="EndType"/> is "date".
        /// </summary>
        public string EndDateInterval { get; set; }

        /// <summary>
        /// Gets or sets the number of payments after which the recurring payment should end.
        /// Used when <see cref="EndType"/> is "count".
        /// </summary>
        public int? EndAfterNumberOfPayments { get; set; }

        /// <summary>
        /// Gets or sets the total amount in cents after which the recurring payment should end.
        /// Used when <see cref="EndType"/> is "amount".
        /// </summary>
        public long? EndAfterTotalAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entire plan should be cancelled if this recurring payment fails.
        /// </summary>
        public bool CancelPlanOnFailure { get; set; }

        /// <summary>
        /// Gets or sets custom metadata associated with the recurring payment.
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets a list of validation or API errors.
        /// </summary>
        public List<ApiError> Errors { get; set; }
    }
}