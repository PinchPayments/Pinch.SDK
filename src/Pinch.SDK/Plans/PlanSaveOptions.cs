using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Plans
{
    public class PlanSaveOptions
    {
        public string Id { get; set; }
        public string PayerId { get; set; }
        public string Name { get; set; }
        public List<PlanFreePeriodSaveOptions> FreePeriods { get; set; } = new List<PlanFreePeriodSaveOptions>();
        public List<PlanFixedPaymentSaveOptions> FixedPayments { get; set; } = new List<PlanFixedPaymentSaveOptions>();
        public PlanRecurringPaymentSaveOptions RecurringPayment { get; set; }
        public string Metadata { get; set; }
    }
}
