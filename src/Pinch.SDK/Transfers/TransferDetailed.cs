using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Transfers
{
    public class TransferDetailed
    {
        public string Id { get; set; }
        public DateTime TransferDate { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public long TotalFees { get; set; }
        public long IncludedTax { get; set; }
        public decimal TaxRate { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Bsb { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public bool IsGrossBilled { get; set; }

        public IEnumerable<TransferSummaryItem> Summary { get; set; } = new List<TransferSummaryItem>();
    }
}
