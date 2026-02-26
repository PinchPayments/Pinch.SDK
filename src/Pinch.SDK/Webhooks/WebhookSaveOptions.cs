using System.Collections.Generic;

namespace Pinch.SDK.Webhooks
{
    /// <summary>
    /// Options for creating or updating a webhook subscription.
    /// </summary>
    public class WebhookSaveOptions
    {
        /// <summary>
        /// Webhook Id in wbk_XXXXXXXXXXXXXX format (for updating existing webhook, leave null to create new)
        /// </summary>
        public string Id { get; set; }

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


        /// <summary>
        /// Optional. API version in format YYYY.M (for example, 2024.1 or 2025.1). Controls the webhook payload schema and related behavior for this subscription.
        /// </summary>
        public string ApiVersion { get; set; }
    }
}
