using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Subscriptions
{
    public class SubscriptionFixedPayment
    {
        public int Amount { get; set; }
        public string Description { get; set; }
        public bool CancelPlanOnFailure { get; set; }
        public string Metadata { get; set; }
        public string TransactionDate { get; set; }
    }
}
