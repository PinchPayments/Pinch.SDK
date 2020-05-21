using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Subscriptions
{
    public class Subscription
    {
        public string Id { get; set; }
        public Payer Payer { get; set; }
        public string PlanId { get; set; }
        public string PlanName { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public IEnumerable<SubscriptionFreePeriod> FreePeriods { get; set; } = new List<SubscriptionFreePeriod>();
        public IEnumerable<SubscriptionFixedPayment> FixedPayments { get; set; } = new List<SubscriptionFixedPayment>();
        public SubscriptionRecurringPayment RecurringPayment { get; set; }
        public string Metadata { get; set; }
        public long? TotalAmount { get; set; }
        public List<string> Surcharge { get; set; } = new List<string>();
    }
}
