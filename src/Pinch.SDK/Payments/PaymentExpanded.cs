using System;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Payments
{
    public class PaymentExpanded
    {
        /// <summary>
        /// The Payment ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The Current Attempt ID. Changes with each change to the payment. Use to correlate with payments that dishonoured and have been retried.
        /// </summary>
        public string AttemptId { get; set; }
        /// <summary>
        /// The transaction amount in cents
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// The given description for this payment
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The application fee, if one was added
        /// </summary>
        public long ApplicationFee { get; set; }
        /// <summary>
        /// The total of all fees for this transaction
        /// </summary>
        public long TotalFee { get; set; }
        /// <summary>
        /// Whether this transaction passed the fees onto the customer
        /// </summary>
        public bool IsSurcharged { get; set; }
        /// <summary>
        /// The Source Type of the source used  eg. 'bank-account', 'credit card'
        /// </summary>
        public string SourceType { get; set; }
        /// <summary>
        /// The date and time of the transaction. In UTC.
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// The date that this payment will most likely be settled. Can change based on several factors, but will usually be accurate.
        /// </summary>
        public DateTime EstimatedTransferDate { get; set; }
        /// <summary>
        /// The status of the payment. eg. 'scheduled', 'processing', 'settled'
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// A free form field for applications to populate data. Metadata from plans and subscriptions will be available here too.
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// The Payer for this payment
        /// </summary>
        public Payer Payer { get; set; }

        /// <summary>
        /// The Nonce that was sent with the initial request
        /// </summary>
        public string Nonce { get; set; }
        /// <summary>
        /// Whether this response is a Nonce replay. 
        /// </summary>
        public bool IsNonceReplay { get; set; }
    }
}
