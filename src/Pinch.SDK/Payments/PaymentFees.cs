using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Payments
{
    public class PaymentFees
    {
        /// <summary>
        /// The fee to execute the transaction. Includes Tax.
        /// </summary>
        public long TransactionFee { get; set; }
        /// <summary>
        /// If a parent merchant also charges a fee, that fee appears here. Includes Tax.
        /// </summary>
        public long ApplicationFee { get; set; }
        /// <summary>
        /// All fees combined for this transaction. Includes Tax.
        /// </summary>
        public long TotalFee { get; set; }
        /// <summary>
        /// The tax rate used for all fees.
        /// </summary>
        public decimal TaxRate { get; set; }
    }
}
