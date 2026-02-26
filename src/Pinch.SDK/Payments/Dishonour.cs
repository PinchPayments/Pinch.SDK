using System;

namespace Pinch.SDK.Payments
{
    public class Dishonour
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }
        public long Fees { get; set; }

        public string TransferId { get; set; }

        public PaymentExpanded Payment { get; set; }
    }
}
