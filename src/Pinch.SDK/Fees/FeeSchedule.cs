using System;
using System.Collections.Generic;

namespace Pinch.SDK.Fees
{
    /// <summary>
    /// Represents a fee schedule that defines the fees and charges applicable for direct debit transactions.
    /// </summary>
    public class FeeSchedule
    {
        /// <summary>
        /// Gets or sets the direct debit transfer fee amount in the smallest currency unit (e.g., cents).
        /// </summary>
        public long DirectDebitTransferFee { get; set; }

        /// <summary>
        /// Gets or sets the tax rate applied to fees as a decimal value (e.g., 0.10 for 10%).
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the date and time in UTC when this fee schedule becomes effective.
        /// </summary>
        public DateTime EffectiveDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the identifier or name of the person who authorized this fee schedule.
        /// </summary>
        public string AuthorisedBy { get; set; }

        /// <summary>
        /// Gets or sets additional notes or comments about this fee schedule.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the current status of the fee schedule.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the collection of fee schedule line items that define specific fee details.
        /// </summary>
        public List<FeeScheduleLine> FeeScheduleLines { get; set; } = new List<FeeScheduleLine>();
    }
}
