using System.Collections.Generic;
using Pinch.SDK.Payments;

namespace Pinch.SDK.Events
{
    /// <summary>
    /// Represents an event containing bank result payments.
    /// </summary>
    public class BankResultsEvent
    {
        /// <summary>
        /// Gets or sets the collection of bank result payments.
        /// </summary>
        public IEnumerable<BankResultPayment> Payments { get; set; } = new List<BankResultPayment>();
    }
}
