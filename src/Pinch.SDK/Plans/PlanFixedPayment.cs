using System;

namespace Pinch.SDK.Plans
{
    public class PlanFixedPayment
    {
        public long? AmountInCents { get; set; }
        public decimal? AmountPercentage { get; set; }
        public string Description { get; set; }
        public int ScheduledDateOffset { get; set; }
        public string ScheduledDateInterval { get; set; }
        public bool CancelPlanOnFailure { get; set; }
        public string Metadata { get; set; }
    }
}