using Pinch.SDK.Transfers;

namespace Pinch.SDK.Events
{
    /// <summary>
    /// Represents an event related to a transfer.
    /// </summary>
    public class TransferEvent
    {
        /// <summary>
        /// Gets or sets the transfer associated with this event.
        /// </summary>
        public Transfer Transfer { get; set; }
    }
}
