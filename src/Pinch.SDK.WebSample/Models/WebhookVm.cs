using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.WebSample.Models
{
    public class WebhookVm
    {
        public string Uri { get; set; }
        public string WebhookFormat { get; set; }
        public string EventTypes { get; set; }
    }
}
