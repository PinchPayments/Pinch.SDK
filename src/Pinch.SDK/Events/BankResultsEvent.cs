using System.Collections.Generic;
using Pinch.SDK.Payments;

namespace Pinch.SDK.Events
{
    public class BankResultsEvent
    {
        public IEnumerable<BankResultPayment> Payments { get; set; } = new List<BankResultPayment>();
    }
}
