using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Events
{
    public class EventDetailed
    {
        public string Id { get; set; }
        public string Type { get; set; }

        public DateTime EventDate { get; set; }
        public dynamic Metadata { get; set; }
        public dynamic Data { get; set; }
    }
}
