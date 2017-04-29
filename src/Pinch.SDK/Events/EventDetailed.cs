using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pinch.SDK.Events
{
    public class EventDetailed
    {
        public string Id { get; set; }
        public string Type { get; set; }

        public DateTime EventDate { get; set; }
        public dynamic Metadata { get; set; }
        public dynamic Data { get; set; }

        public EventDetailed<BankResultsEvent> ToBankResultsEvent()
        {
            return new EventDetailed<BankResultsEvent>(this);
        }

        public EventDetailed<TransferEvent> ToTransferEvent()
        {
            return new EventDetailed<TransferEvent>(this);
        }

        public EventDetailed<ScheduledProcessEvent> ToScheduledProcessEvent()
        {
            return new EventDetailed<ScheduledProcessEvent>(this);
        }
    }

    public class EventDetailed<T> : EventDetailed
    {
        public new T Data { get; set; }

        public EventDetailed(EventDetailed evt)
        {
            // Weirdly, you need to be specific with string here.
            string intermediate = JsonConvert.SerializeObject(evt.Data);
            Data = JsonConvert.DeserializeObject<T>(intermediate);
        }
    }
}
