using System;

namespace Pinch.SDK.Plans
{
    public class PlanRecurringPayment
    {
        public long? AmountInCents { get; set; }
        public decimal? AmountPercentage { get; set; }
        public string Description { get; set; }
        public int StartDateOffset { get; set; }
        public string StartDateInterval { get; set; }
        public int FrequencyOffset { get; set; }
        public string FrequencyInterval { get; set; }
        public string EndType { get; set; }
        public int? EndDateOffset { get; set; }
        public string EndDateInterval { get; set; }
        public int? EndAfterNumberOfPayments { get; set; }
        public long? EndAfterTotalAmount { get; set; }
        public bool CancelPlanOnFailure { get; set; }
        public string Metadata { get; set; }
    }
}