using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Payments
{
    public class Attempt
    {
        /// <summary>
        /// The transaction amount in cents
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// The date that this payment will most likely be settled. Can change based on several factors, but will usually be accurate.
        /// </summary>
        public DateTime EstimatedTransferDate { get; set; }
        /// <summary>
        /// The actual date the payment was settled. Only available once settled.
        /// </summary>
        public DateTime? ActualTransferDate { get; set; }
        /// <summary>
        /// The date and time of the transaction. In UTC.
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// The status of the attempt. eg. 'scheduled', 'processing', 'settled'
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The Source used to execute the payment
        /// </summary>
        public Source Source { get; set; }
        /// <summary>
        /// If the payment was declined, the dishonour details are given here.
        /// </summary>
        public Dishonour Dishonour { get; set; }
        /// <summary>
        /// Contains settlement details for payments that have been settled.
        /// </summary>
        public Settlement Settlement { get; set; }
        /// <summary>
        /// The fee breakdown for this attempt.
        /// </summary>
        public PaymentFees Fees { get; set; }
        /// <summary>
        /// Whether this transaction passed the fees onto the customer
        /// </summary>
        public bool IsSurcharged { get; set; }
    }
}
