using System;
using System.Collections.Generic;

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
        /// A list of source types to surcharge (Pass on the fees to the customer). eg. ['bank-account', 'credit-card']
        /// </summary>
        public List<string> Surcharge { get; set; } = new List<string>();

        /// <summary>
        /// Optional. Pinch will echo back the nonce value in the response, this is for replay protection.
        /// If the same Nonce is detected the in progress payment object will be returned.
        /// </summary>
        public string Nonce { get; set; }
    }
}
