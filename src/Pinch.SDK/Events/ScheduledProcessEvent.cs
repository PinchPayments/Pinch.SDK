using System.Collections.Generic;
using Pinch.SDK.Payments;

namespace Pinch.SDK.Events
{
    /// <summary>
    /// Represents an event that occurs during scheduled payment processing.
    /// </summary>
    public class ScheduledProcessEvent
    {
        /// <summary>
        /// Gets or sets the collection of payments associated with this scheduled process event.
        /// </summary>
        public IEnumerable<PaymentExpanded> Payments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledProcessEvent"/> class.
        /// </summary>
        public ScheduledProcessEvent()
        {
            Payments = new List<PaymentExpanded>();
        }
    }
}
