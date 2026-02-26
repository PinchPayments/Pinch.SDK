using System.Collections.Generic;

namespace Pinch.SDK.Webhooks
{
    /// <summary>
    /// Represents a webhook configuration for receiving event notifications.
    /// </summary>
    /// <remarks>
    /// A webhook allows the SDK to push event notifications to a specified URI endpoint.
    /// The webhook includes configuration for the target endpoint, event types to monitor,
    /// and authentication details for securing the webhook delivery.
    /// </remarks>
    public class Webhook
    {
        /// <summary>
        /// Gets or sets the unique identifier for the webhook.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the secret key used for authenticating and validating webhook requests.
        /// </summary>
        /// <remarks>
        /// This secret should be used to verify the authenticity of webhook events delivered
        /// to the specified URI endpoint.
        /// </remarks>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the URI endpoint where webhook events will be delivered.
        /// </summary>
        /// <remarks>
        /// This must be a valid, publicly accessible HTTPS endpoint capable of receiving
        /// POST requests.
        /// </remarks>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the format of the webhook payload (e.g., JSON, XML).
        /// </summary>
        public string WebhookFormat { get; set; }

        /// <summary>
        /// Gets or sets the API version for the webhook events.
        /// </summary>
        /// <remarks>
        /// This determines the structure and content of webhook event payloads.
        /// </remarks>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the list of event types that trigger this webhook.
        /// </summary>
        /// <remarks>
        /// Only events matching types in this list will be delivered to the webhook endpoint.
        /// </remarks>
        public List<string> EventTypes { get; set; }
    }
}
