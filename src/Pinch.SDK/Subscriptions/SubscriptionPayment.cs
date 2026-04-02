namespace Pinch.SDK.Subscriptions
{
    /// <summary>
    /// Represents a payment associated with a subscription plan.
    /// </summary>
    public class SubscriptionPayment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the subscription payment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the subscription plan associated with this payment.
        /// </summary>
        public string PlanId { get; set; }

        /// <summary>
        /// Gets or sets the name of the subscription plan associated with this payment.
        /// </summary>
        public string PlanName { get; set; }
    }
}
