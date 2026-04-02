namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Represents a recurring payment configuration for a subscription plan.
    /// </summary>
    public class PlanRecurringPayment
    {
        /// <summary>
        /// Gets or sets the fixed amount to charge in cents.
        /// Mutually exclusive with <see cref="AmountPercentage"/>.
        /// </summary>
        public long? AmountInCents { get; set; }

        /// <summary>
        /// Gets or sets the percentage amount to charge.
        /// Mutually exclusive with <see cref="AmountInCents"/>.
        /// </summary>
        public decimal? AmountPercentage { get; set; }

        /// <summary>
        /// Gets or sets the description of the recurring payment.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of units to offset the start date by.
        /// Used in conjunction with <see cref="StartDateInterval"/>.
        /// </summary>
        public int StartDateOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval unit for the start date offset (e.g., "days", "weeks", "months", "years").
        /// </summary>
        public string StartDateInterval { get; set; }

        /// <summary>
        /// Gets or sets the number of units between each recurring payment.
        /// Used in conjunction with <see cref="FrequencyInterval"/>.
        /// </summary>
        public int FrequencyOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval unit for the payment frequency (e.g., "days", "weeks", "months", "years").
        /// </summary>
        public string FrequencyInterval { get; set; }

        /// <summary>
        /// Gets or sets the type of end condition for the recurring payment (e.g., "date", "number_of_payments", "total_amount").
        /// </summary>
        public string EndType { get; set; }

        /// <summary>
        /// Gets or sets the number of units to offset the end date by.
        /// Used in conjunction with <see cref="EndDateInterval"/> when <see cref="EndType"/> is "date".
        /// </summary>
        public int? EndDateOffset { get; set; }

        /// <summary>
        /// Gets or sets the interval unit for the end date offset (e.g., "days", "weeks", "months", "years").
        /// </summary>
        public string EndDateInterval { get; set; }

        /// <summary>
        /// Gets or sets the number of payments after which the recurring payment should end.
        /// Used when <see cref="EndType"/> is "number_of_payments".
        /// </summary>
        public int? EndAfterNumberOfPayments { get; set; }

        /// <summary>
        /// Gets or sets the total amount in cents after which the recurring payment should end.
        /// Used when <see cref="EndType"/> is "total_amount".
        /// </summary>
        public long? EndAfterTotalAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entire plan should be cancelled if a payment fails.
        /// </summary>
        public bool CancelPlanOnFailure { get; set; }

        /// <summary>
        /// Gets or sets custom metadata associated with the recurring payment.
        /// </summary>
        public string Metadata { get; set; }
    }
}