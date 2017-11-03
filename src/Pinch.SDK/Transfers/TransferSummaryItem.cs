using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Transfers
{
    public class TransferSummaryItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Gross { get; set; }
        public int Fees { get; set; }
        public int Total { get; set; }
    }
}
