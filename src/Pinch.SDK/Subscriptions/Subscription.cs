using System.Collections.Generic;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Subscriptions
{
    /// <summary>
    /// Represents a subscription in the Pinch payment system.
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Gets or sets the unique identifier for the subscription.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the payer associated with this subscription.
        /// </summary>
        public Payer Payer { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the plan associated with this subscription.
        /// </summary>
        public string PlanId { get; set; }

        /// <summary>
        /// Gets or sets the name of the plan associated with this subscription.
        /// </summary>
        public string PlanName { get; set; }

        /// <summary>
        /// Gets or sets the current status of the subscription.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the start date of the subscription.
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the collection of free periods associated with this subscription.
        /// </summary>
        public IEnumerable<SubscriptionFreePeriod> FreePeriods { get; set; } = new List<SubscriptionFreePeriod>();

        /// <summary>
        /// Gets or sets the collection of fixed payments associated with this subscription.
        /// </summary>
        public IEnumerable<SubscriptionFixedPayment> FixedPayments { get; set; } = new List<SubscriptionFixedPayment>();

        /// <summary>
        /// Gets or sets the recurring payment details for this subscription.
        /// </summary>
        public SubscriptionRecurringPayment RecurringPayment { get; set; }

        /// <summary>
        /// Gets or sets additional metadata for the subscription.
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the subscription.
        /// </summary>
        public long? TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the list of surcharges applied to this subscription.
        /// </summary>
        public List<string> Surcharge { get; set; } = new List<string>();
    }
}
