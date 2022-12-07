﻿namespace Pinch.SDK.WebSample.ViewModels.Subscriptions
{
    public class SubscriptionCreateVm
    {
        public string PayerId { get; set; }
        public string PlanId { get; set; }
        public DateTime? StartDate { get; set; }
        public long? TotalAmount { get; set; }
    }
}
