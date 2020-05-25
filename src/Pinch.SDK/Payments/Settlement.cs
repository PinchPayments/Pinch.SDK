using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Payments
{
    public class Settlement
    {
        /// <summary>
        /// The date this payment was settled
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// The total fees for this settlement
        /// </summary>
        public long Fees { get; set; }
        /// <summary>
        /// The Transfer ID for this settlement
        /// </summary>
        public string TransferId { get; set; }
    }
}
