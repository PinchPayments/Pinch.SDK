namespace Pinch.SDK.Subscriptions
{
    /// <summary>
    /// Represents the configuration for a recurring payment within a subscription.
    /// </summary>
    /// <remarks>
    /// This class defines the parameters that control how recurring payments are processed,
    /// including payment amount, frequency, duration, and behavior on failure.
    /// </remarks>
    public class SubscriptionRecurringPayment
    {
        /// <summary>
        /// Gets or sets the payment amount in the smallest currency unit (e.g., cents).
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of payments to process before ending the recurring payment cycle.
        /// </summary>
        /// <remarks>
        /// If set, the recurring payment will stop after this number of payments has been completed.
        /// Null indicates no limit on the number of payments.
        /// </remarks>
        public int? EndAfterNumberOfPayments { get; set; }

        /// <summary>
        /// Gets or sets the maximum total cumulative amount to charge before ending the recurring payment cycle.
        /// </summary>
        /// <remarks>
        /// If set, the recurring payment will stop once the cumulative amount reaches this threshold.
        /// Null indicates no limit on the total amount.
        /// </remarks>
        public long? EndAfterTotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the frequency interval for recurring payments (e.g., "daily", "weekly", "monthly", "yearly").
        /// </summary>
        public string FrequencyInterval { get; set; }

        /// <summary>
        /// Gets or sets the offset applied to the frequency interval for calculating payment dates.
        /// </summary>
        /// <remarks>
        /// For example, an offset of 2 with a "weekly" interval would execute payments every 2 weeks.
        /// </remarks>
        public int FrequencyOffset { get; set; }

        /// <summary>
        /// Gets or sets a human-readable description of the recurring payment.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subscription plan should be cancelled if a payment fails.
        /// </summary>
        /// <remarks>
        /// When true, a failed payment will automatically cancel the subscription.
        /// When false, the subscription will remain active and may retry the payment.
        /// </remarks>
        public bool CancelPlanOnFailure { get; set; }

        /// <summary>
        /// Gets or sets custom metadata associated with the recurring payment.
        /// </summary>
        /// <remarks>
        /// This can be used to store additional application-specific information about the payment.
        /// </remarks>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the date after which recurring payments should stop.
        /// </summary>
        /// <remarks>
        /// Payments scheduled after this date will not be processed.
        /// Null indicates no end date limit.
        /// </remarks>
        public string EndAfterDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the recurring payment cycle should begin.
        /// </summary>
        /// <remarks>
        /// The first payment will be scheduled on or after this date.
        /// </remarks>
        public string StartDate { get; set; }
    }
}
