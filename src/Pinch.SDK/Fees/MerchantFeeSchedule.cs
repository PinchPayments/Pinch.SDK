using System;
using System.Collections.Generic;

namespace Pinch.SDK.Fees
{
    public class MerchantFeeSchedule
    {
        public DateTime EffectiveDateUtc { get; set; }
        public List<FeeScheduleLine> FeeScheduleLines { get; set; } = new List<FeeScheduleLine>();
    }
}
