using Pinch.SDK.Plans;

namespace Pinch.SDK.WebSample.ViewModels.Plans
{
    public class PlanDetailsVm
    {
        public Plan Plan { get; set; }
        public List<CalculatedSubscriptionPayment> CalculatedPayments { get; set; } = new List<CalculatedSubscriptionPayment>();
    }
}
