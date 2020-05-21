using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Subscriptions
{
    public class SubscriptionCreateOptions
    {
        /// <summary>
        /// The Plan ID to create a subscription from
        /// </summary>
        public string PlanId { get; set; }

        /// <summary>
        /// The ID of the Payer who will subscribe to the plan
        /// </summary>
        public string PayerId { get; set; }

        /// <summary>
        /// The Total Amount to pay for this subscription. If using percentage based plans, this is required.
        /// </summary>
        public long? TotalAmount { get; set; }

        /// <summary>
        /// The date that the subscription will start. If left blank, it will start immediately.
        /// </summary>
        public DateTime? StartDate { get; set; }
        
        /// <summary>
        /// A list of source types to surcharge (Pass on the fees to the customer). eg. ['bank-account', 'credit-card']
        /// </summary>
        public List<string> Surcharge { get; set; } = new List<string>();
    }
}
