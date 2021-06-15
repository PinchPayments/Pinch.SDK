using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Payments
{
    public class BankResultPayment
    {
        public string Id { get; set; }
        public string AttemptId { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; }

        public string TransactionProvider { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Status { get; set; }

        public DateTime EstimatedTransferDate { get; set; }

        public Payer Payer { get; set; }

        public Dishonour Dishonour { get; set; }
    }
}
