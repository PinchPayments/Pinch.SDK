using System.Collections.Generic;
using Pinch.SDK.Payments;
using Pinch.SDK.Plans;
using Pinch.SDK.Subscriptions;

namespace Pinch.SDK.WebSample.ViewModels.Subscriptions
{
    public class SubscriptionDetailsVm
    {
        public Subscription Subscription { get; set; }
        public List<PaymentExpanded> Payments { get; set; } = new List<PaymentExpanded>();
    }
}
