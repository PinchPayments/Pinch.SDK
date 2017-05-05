using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Payers;
using Pinch.SDK.Payments;

namespace Pinch.SDK.WebSample.Models
{
    public class PayerDetailsVm
    {
        public PayerDetailed Payer { get; set; }
        public IEnumerable<PaymentExpanded> Payments { get; set; }

        public PayerDetailsVm()
        {
            Payments = new List<PaymentExpanded>();
        }
    }
}
