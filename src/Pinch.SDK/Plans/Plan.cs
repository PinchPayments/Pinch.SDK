using System.Collections.Generic;

namespace Pinch.SDK.Plans
{
    public class Plan
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PlanFreePeriod> FreePeriods { get; set; } = new List<PlanFreePeriod>();
        public IEnumerable<PlanFixedPayment> FixedPayments { get; set; } = new List<PlanFixedPayment>();
        public PlanRecurringPayment RecurringPayment { get; set; }
        public string Metadata { get; set; }
        public int SubscriberCount { get; set; }
        public bool RequiresTotalAmount { get; set; }
    }
}
