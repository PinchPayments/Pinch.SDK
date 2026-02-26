using System.Collections.Generic;
using Pinch.SDK.Payments;

namespace Pinch.SDK.Events
{
    public class ScheduledProcessEvent
    {
        public IEnumerable<PaymentExpanded> Payments { get; set; }

        public ScheduledProcessEvent()
        {
            Payments = new List<PaymentExpanded>();
        }
    }
}
