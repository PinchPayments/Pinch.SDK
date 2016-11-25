using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Payments
{
    public class PaymentDetailed
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public Payer Payer { get; set; }
        public IEnumerable<Attempt> Attempts { get; set; }

        public PaymentDetailed()
        {
            Attempts = new List<Attempt>();
        }
    }
}
