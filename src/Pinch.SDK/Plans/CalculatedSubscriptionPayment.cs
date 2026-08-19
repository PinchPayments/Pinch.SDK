using System;

namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Represents a calculated payment for a subscription plan, including the amount, date, and description.
    /// </summary>
    public class CalculatedSubscriptionPayment
    {
        /// <summary>
        /// Gets or sets the payment amount in cents.
        /// </summary>
        /// <value>The payment amount expressed in cents (e.g., 1000 = $10.00).</value>
        public long AmountInCents { get; set; }
        
        /// <summary>
        /// Gets or sets the description of the payment.
        /// </summary>
        /// <value>A text description providing details about the payment.</value>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the scheduled date for the payment.
        /// </summary>
        /// <value>The date and time when the payment is scheduled to occur.</value>
        public DateTime PaymentDate { get; set; }
        
        /// <summary>
        /// Gets or sets the index of the recurring payment in the subscription sequence.
        /// </summary>
        /// <value>
        /// The zero-based index of this payment in the recurring payment schedule, 
        /// or <c>null</c> if this is not a recurring payment or the index is not applicable.
        /// </value>
        public int? RecurringPaymentIndex { get; set; }
    }
}
