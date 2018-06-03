using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK
{
    public class PinchApiOptions
    {
        public bool IsLive { get; set; }
        public string BaseUri { get; set; }
        public string AuthUri { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string ApplicationId { get; set; }

        /// <summary>
        /// Set this to specify which version of the API you have coded against. Omitting this in the SDK is fine as we'll
        /// use the most recent version. Used for backwards compatibility.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Set this Merchant ID to impersonate a different merchant.
        /// </summary>
        public string ImpersonateMerchantId { get; set; }

        /// <summary>
        /// The maximum difference in seconds between the current time and the webhook timestamp.
        /// Used to verify authenticity of webhook requests and to avoid replay attacks.
        /// </summary>
        public int WebhookVerificationClockSkewThreshold { get; set; } = 300; // 5 minutes
    }
}
