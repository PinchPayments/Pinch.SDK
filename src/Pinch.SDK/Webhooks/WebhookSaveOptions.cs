using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Webhooks
{
    public class WebhookSaveOptions
    {
        /// <summary>
        /// This is the uri that the webhooks will be sent to.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Optional. See WebhookFormats for the list of available formats. Defaults to PascalCase.
        /// </summary>
        public string WebhookFormat { get; set; }

        /// <summary>
        /// Optional. This is a list of the types of events that will be returned via the webhook. See EventTypes for a list of available events. Defaults to ALL event types. 
        /// </summary>
        public List<string> EventTypes { get; set; }
    }
}
