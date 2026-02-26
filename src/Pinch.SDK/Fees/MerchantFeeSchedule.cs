using System;
using System.Collections.Generic;

namespace Pinch.SDK.Fees
{
    /// <summary>
    /// Represents a merchant fee schedule with an effective date and associated fee schedule lines.
    /// </summary>
    public class MerchantFeeSchedule
    {
        /// <summary>
        /// Gets or sets the effective date (UTC) for this fee schedule.
        /// </summary>
        public DateTime EffectiveDateUtc { get; set; }
        
        /// <summary>
        /// Gets or sets the list of fee schedule lines for this merchant fee schedule.
        /// </summary>
        public List<FeeScheduleLine> FeeScheduleLines { get; set; } = new List<FeeScheduleLine>();
    }
}
