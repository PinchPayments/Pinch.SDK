using System;

namespace Pinch.SDK.Plans
{
    public class CalculatedSubscriptionPayment
    {
        public long AmountInCents { get; set; }
        public string Description { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? RecurringPaymentIndex { get; set; }
    }
}
