using System;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Payments
{
    public class PaymentExpanded
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public Payer Payer { get; set; }
    }
}
