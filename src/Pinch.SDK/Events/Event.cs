using System;

namespace Pinch.SDK.Events
{
    /// <summary>
    /// Represents an event in the Pinch SDK.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the event type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the date when the event occurred.
        /// </summary>
        public DateTime EventDate { get; set; }
        
        /// <summary>
        /// Gets or sets additional metadata for the event.
        /// </summary>
        public dynamic Metadata { get; set; }
    }
}
