using Pinch.SDK.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.WebSample.ViewModels.Plans
{
    public class PlanDetailsVm
    {
        public Plan Plan { get; set; }
        public List<CalculatedSubscriptionPayment> CalculatedPayments { get; set; } = new List<CalculatedSubscriptionPayment>();
    }
}
