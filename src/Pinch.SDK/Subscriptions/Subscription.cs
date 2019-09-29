using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Subscriptions
{
    public class Subscription
    {
        public string Id { get; set; }
        public string PayerId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public IEnumerable<SubscriptionFreePeriod> FreePeriods { get; set; } = new List<SubscriptionFreePeriod>();
        public IEnumerable<SubscriptionFixedPayment> FixedPayments { get; set; } = new List<SubscriptionFixedPayment>();
        public SubscriptionRecurringPayment RecurringPayment { get; set; }
        public string Metadata { get; set; }
    }
}
