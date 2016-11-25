using System;

namespace Pinch.SDK.Payments
{
    public class Payment
    {
        public string Id { get; set; }
        public string PayerId { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
