using System;
using System.Collections.Generic;

namespace Pinch.SDK.Fees
{
    public class FeeScheduleSaveOptions
    {
        public long DirectDebitTransferFee { get; set; }
        public decimal TaxRate { get; set; }

        public DateTime? EffectiveDateUtc { get; set; }
        public string Notes { get; set; }
        public string MerchantId { get; set; }

        public List<FeeScheduleLineSaveRequest> FeeScheduleLines { get; set; } = new List<FeeScheduleLineSaveRequest>();

    }

    public class FeeScheduleLineSaveRequest
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
