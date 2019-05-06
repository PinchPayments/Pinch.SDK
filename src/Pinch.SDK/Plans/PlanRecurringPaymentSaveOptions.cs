using System;

namespace Pinch.SDK.Plans
{
    public class PlanRecurringPaymentSaveOptions
    {
        public int Amount { get; set; }
        public DateTime StartDate { get; set; }
        public int? EndAfterNumberOfPayments { get; set; }
        public long? EndAfterTotalAmount { get; set; }
        public DateTime? EndAfterDate { get; set; }
        public string FrequencyInterval { get; set; }
        public int FrequencyLength { get; set; }
        public string Description { get; set; }
        public bool CancelPlanOnFailure { get; set; }
        public string Metadata { get; set; }
    }
}