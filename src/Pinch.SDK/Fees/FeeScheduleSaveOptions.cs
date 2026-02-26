using System;
using System.Collections.Generic;

namespace Pinch.SDK.Fees
{
    /// <summary>
    /// Options for saving a fee schedule.
    /// </summary>
    public class FeeScheduleSaveOptions
    {
        /// <summary>
        /// Gets or sets the direct debit transfer fee.
        /// </summary>
        public long DirectDebitTransferFee { get; set; }
        
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the effective date in UTC.
        /// </summary>
        public DateTime? EffectiveDateUtc { get; set; }
        
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        public string Notes { get; set; }
        
        /// <summary>
        /// Gets or sets the merchant identifier.
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets the fee schedule lines.
        /// </summary>
        public List<FeeScheduleLineSaveRequest> FeeScheduleLines { get; set; } = new List<FeeScheduleLineSaveRequest>();

    }
}
