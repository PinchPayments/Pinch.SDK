namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Represents a fixed, one-time payment associated with a subscription plan.
    /// </summary>
    /// <remarks>
    /// A fixed payment is charged on a specific schedule as part of a subscription plan,
    /// independent of recurring charges. Fixed payments can be specified as an absolute amount
    /// in cents or as a percentage of the subscription value. They are scheduled at defined
    /// intervals and offsets, and can be configured to cancel the plan if they fail.
    /// </remarks>
    public class PlanFixedPayment
    {
        /// <summary>
        /// Gets or sets the fixed payment amount in cents (1/100th of a currency unit).
        /// </summary>
        /// <remarks>
        /// This is a nullable long value. Either <see cref="AmountInCents"/> or <see cref="AmountPercentage"/>
        /// should be specified, but not both. If neither is specified, the payment amount must be determined
        /// by other means during subscription processing.
        /// </remarks>
        public long? AmountInCents { get; set; }

        /// <summary>
        /// Gets or sets the fixed payment amount as a percentage of the subscription value.
        /// </summary>
        /// <remarks>
        /// This is a nullable decimal value representing a percentage (e.g., 10.5 for 10.5%).
        /// Either <see cref="AmountInCents"/> or <see cref="AmountPercentage"/> should be specified,
        /// but not both. If neither is specified, the payment amount must be determined
        /// by other means during subscription processing.
        /// </remarks>
        public decimal? AmountPercentage { get; set; }

        /// <summary>
        /// Gets or sets a description of the fixed payment.
        /// </summary>
        /// <remarks>
        /// This optional field can be used to provide human-readable information about the purpose
        /// or details of the fixed payment, such as "Setup fee" or "Administrative charge".
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the offset value for scheduling the fixed payment.
        /// </summary>
        /// <remarks>
        /// This value is interpreted in conjunction with <see cref="ScheduledDateInterval"/>.
        /// For example, an offset of 14 with an interval of "days" schedules the payment 14 days
        /// from the start of the subscription.
        /// </remarks>
        public int ScheduledDateOffset { get; set; }

        /// <summary>
        /// Gets or sets the time interval unit for the scheduled payment date.
        /// </summary>
        /// <remarks>
        /// This typically specifies the unit of time for <see cref="ScheduledDateOffset"/>,
        /// such as "days", "weeks", or "months". The interval determines how <see cref="ScheduledDateOffset"/>
        /// is applied to calculate the payment date.
        /// </remarks>
        public string ScheduledDateInterval { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subscription plan should be cancelled
        /// if this fixed payment fails to process.
        /// </summary>
        /// <remarks>
        /// When set to <c>true</c>, a failed payment attempt for this fixed payment will result in
        /// the entire subscription plan being cancelled. When <c>false</c>, plan cancellation is not
        /// triggered by payment failure, allowing the subscription to continue.
        /// </remarks>
        public bool CancelPlanOnFailure { get; set; }

        /// <summary>
        /// Gets or sets optional metadata associated with the fixed payment.
        /// </summary>
        /// <remarks>
        /// This field can store arbitrary key-value data as a string (typically JSON format)
        /// for custom use cases or integration with external systems. It does not affect
        /// payment processing but can be used for tracking and reference purposes.
        /// </remarks>
        public string Metadata { get; set; }
    }
}