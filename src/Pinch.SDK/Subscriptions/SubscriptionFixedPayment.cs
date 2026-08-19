namespace Pinch.SDK.Subscriptions
{
    /// <summary>
    /// Represents a fixed payment for a subscription.
    /// </summary>
    public class SubscriptionFixedPayment
    {
        /// <summary>
        /// Gets or sets the payment amount.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the payment description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subscription plan should be canceled if this payment fails.
        /// </summary>
        public bool CancelPlanOnFailure { get; set; }

        /// <summary>
        /// Gets or sets additional metadata for the payment.
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        public string TransactionDate { get; set; }
    }
}
