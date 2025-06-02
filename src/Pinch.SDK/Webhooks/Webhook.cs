using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Webhooks
{
    public class Webhook
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Uri { get; set; }
        public string WebhookFormat { get; set; }
        public List<string> EventTypes { get; set; }
    }
}
