using System.Collections.Generic;

namespace Pinch.SDK.Plans
{
    public class PlanSaveOptions
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<PlanFreePeriodSaveOptions> FreePeriods { get; set; } = new List<PlanFreePeriodSaveOptions>();
        public List<PlanFixedPaymentSaveOptions> FixedPayments { get; set; } = new List<PlanFixedPaymentSaveOptions>();
        public PlanRecurringPaymentSaveOptions RecurringPayment { get; set; }
        public string Metadata { get; set; }
        public List<ApiError> Errors { get; set; }
    }
}
