using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Payments
{
    public class Attempt
    {
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
