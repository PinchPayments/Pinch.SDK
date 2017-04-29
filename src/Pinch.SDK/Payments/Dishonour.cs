using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Payments
{
    public class Dishonour
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }
        public long Fees { get; set; }

        public string TransferId { get; set; }

        public PaymentExpanded Payment { get; set; }
    }
}
