using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Subscriptions
{
    public class SubscriptionCreateOptions
    {
        public string PlanId { get; set; }
        public string PayerId { get; set; }
        public long? TotalAmount { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
