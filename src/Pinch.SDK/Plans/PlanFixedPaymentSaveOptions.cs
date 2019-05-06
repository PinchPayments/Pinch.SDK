using System;

namespace Pinch.SDK.Plans
{
    public class PlanFixedPaymentSaveOptions
    {
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public bool CancelPlanOnFailure { get; set; }
        public string Metadata { get; set; }
    }
}