using System;

namespace Pinch.SDK.Payments
{
    public class PaymentSaveOptions
    {
        /// <summary>
        /// Payment ID. Leave blank to create a new Payment.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The Payer ID of the Payer to debit.
        /// </summary>
        public string PayerId { get; set; }
        /// <summary>
        /// The payment amount in cents. eg. $10.00 = 1000
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// The date to take the payment. If submitted outside of banking hours on the scheduled date, the payment will be taken the next business day.
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// A description of the payment. This may be shown to the Payer to understand the payment.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Optional. The ID of the payment Source you want to use. If omitted, the first valid source will be used. 
        /// </summary>
        public string SourceId { get; set; }
        /// <summary>
        /// This can only be used by trusted/internal clients. It allows you to select which merchant the payer will be added to.
        /// </summary>
        public string MerchantId { get; set; }
    }
}
