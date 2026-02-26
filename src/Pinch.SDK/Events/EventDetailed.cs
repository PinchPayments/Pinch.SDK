using System;
using Newtonsoft.Json;

namespace Pinch.SDK.Events
{
    /// <summary>
    /// Represents a detailed event from the Pinch API with dynamic data and metadata.
    /// </summary>
    public class EventDetailed
    {
        /// <summary>
        /// Gets or sets the unique identifier of the event.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the event occurred.
        /// </summary>
        public DateTime EventDate { get; set; }
        
        /// <summary>
        /// Gets or sets the metadata associated with the event.
        /// </summary>
        public dynamic Metadata { get; set; }
        
        /// <summary>
        /// Gets or sets the dynamic data payload of the event.
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Converts this event to a strongly-typed bank results event.
        /// </summary>
        /// <returns>An <see cref="EventDetailed{T}"/> instance with <see cref="BankResultsEvent"/> data.</returns>
        public EventDetailed<BankResultsEvent> ToBankResultsEvent()
        {
            return new EventDetailed<BankResultsEvent>(this);
        }

        /// <summary>
        /// Converts this event to a strongly-typed transfer event.
        /// </summary>
        /// <returns>An <see cref="EventDetailed{T}"/> instance with <see cref="TransferEvent"/> data.</returns>
        public EventDetailed<TransferEvent> ToTransferEvent()
        {
            return new EventDetailed<TransferEvent>(this);
        }

        /// <summary>
        /// Converts this event to a strongly-typed scheduled process event.
        /// </summary>
        /// <returns>An <see cref="EventDetailed{T}"/> instance with <see cref="ScheduledProcessEvent"/> data.</returns>
        public EventDetailed<ScheduledProcessEvent> ToScheduledProcessEvent()
        {
            return new EventDetailed<ScheduledProcessEvent>(this);
        }
    }

    /// <summary>
    /// Represents a strongly-typed detailed event from the Pinch API.
    /// </summary>
    /// <typeparam name="T">The type of the event data.</typeparam>
    public class EventDetailed<T> : EventDetailed
    {
        /// <summary>
        /// Gets or sets the strongly-typed data payload of the event.
        /// </summary>
        public new T Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventDetailed{T}"/> class
        /// by converting the dynamic data from an <see cref="EventDetailed"/> instance.
        /// </summary>
        /// <param name="evt">The source event with dynamic data to convert.</param>
        public EventDetailed(EventDetailed evt)
        {
            // Weirdly, you need to be specific with string here.
            string intermediate = JsonConvert.SerializeObject(evt.Data);
            Data = JsonConvert.DeserializeObject<T>(intermediate);
        }
    }
}
