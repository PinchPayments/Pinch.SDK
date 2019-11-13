using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Plans
{
    public class CalculatedSubscriptionPayment
    {
        public long AmountInCents { get; set; }
        public string Description { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
