using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Fees
{
    public class FeeSchedule
    {
        public long DirectDebitTransferFee { get; set; }
        public decimal TaxRate { get; set; }
        public DateTime EffectiveDateUtc { get; set; }
        public string AuthorisedBy { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public List<FeeScheduleLine> FeeScheduleLines { get; set; } = new List<FeeScheduleLine>();
    }

    public class FeeScheduleLine
    {
        public string DestinationZone { get; set; }
        public string OriginZone { get; set; }
        public string FeeScheme { get; set; }
        public decimal PercentageFee { get; set; }
        public long FixedFee { get; set; }
        public long Cap { get; set; }
        public long DishonourFee { get; set; }
        public long DisputeFee { get; set; }
    }
}
