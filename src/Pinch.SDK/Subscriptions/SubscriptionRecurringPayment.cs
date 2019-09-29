using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Subscriptions
{
    public class SubscriptionRecurringPayment
    {
        public long Amount { get; set; }
        public int? EndAfterNumberOfPayments { get; set; }
        public long? EndAfterTotalAmount { get; set; }
        public string FrequencyInterval { get; set; }
        public int FrequencyOffset { get; set; }
        public string Description { get; set; }
        public bool CancelPlanOnFailure { get; set; }
        public string Metadata { get; set; }
        public string EndAfterDate { get; set; }
        public string StartDate { get; set; }
    }
}
