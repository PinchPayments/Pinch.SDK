using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pinch.SDK.Payments;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Fees
{
    public class FeesCalculation
    {
        public long Amount { get; set; }
        public string Currency { get; set; }
        public long NetAmount { get; set; }
        public bool IsSurcharged { get; set; }
        public long? ConvertedAmount { get; set; }
        public string ConvertedCurrency { get; set; }
        public long? ConvertedNetAmount { get; set; }

        public PaymentFees Fees { get; set; }
        public Source Source { get; set; }
        public FeeScheduleLine FeeSchedule { get; set; }
    }
}
