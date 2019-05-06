using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Plans
{
    public class Plan
    {
        public string Id { get; set; }
        public string PayerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<PlanFreePeriod> FreePeriods { get; set; } = new List<PlanFreePeriod>();
        public IEnumerable<PlanFixedPayment> FixedPayments { get; set; } = new List<PlanFixedPayment>();
        public PlanRecurringPayment RecurringPayment { get; set; }
    }
}
