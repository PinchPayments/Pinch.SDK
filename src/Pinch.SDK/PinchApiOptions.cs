using System.Collections.Generic;

namespace Pinch.SDK
{
    public class PinchApiOptions
    {
        public PinchApiOptions(
            bool? isLive = null,
            string baseUri = null,
            string authUri = null,
            string accessToken = null,
            string refreshToken = null,
            string applicationId = null,
            string apiVersion = null,
            string impersonateMerchantId = null,
            int? webhookVerificationClockSkewThreshold = null,
            List<string> additionalScopes = null)
        {
            IsLive = isLive ?? false;
            ApiVersion = !string.IsNullOrEmpty(apiVersion)
                ? apiVersion
                : Settings.LatestApiVersion;

            if (!string.IsNullOrEmpty(baseUri))
            {
                BaseUri = $"{baseUri.TrimEnd('/')}/{(IsLive ? "live" : "test")}/";
            }
            else
            {
                BaseUri = IsLive ? Settings.ApiBaseUri_Production : Settings.ApiBaseUri_Test;
            }
            
            AuthUri = !string.IsNullOrEmpty(authUri) ? authUri : Settings.AuthBaseUri_Production;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ApplicationId = applicationId;
            ImpersonateMerchantId = impersonateMerchantId;
            WebhookVerificationClockSkewThreshold = webhookVerificationClockSkewThreshold ?? 300; // Defaults to 5 minutes
            AdditionalScopes = additionalScopes;
        }
        
        public bool IsLive { get; }
        public string BaseUri { get; }
        public string AuthUri { get; }
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public string ApplicationId { get; }

        /// <summary>
        /// Set this to specify which version of the API you have coded against. Omitting this in the SDK is fine as we'll
        /// use the most recent version. Used for backwards compatibility.
        /// </summary>
        public string ApiVersion { get; }

        /// <summary>
        /// Set this Merchant ID to impersonate a different merchant.
        /// </summary>
        public string ImpersonateMerchantId { get; }

        /// <summary>
        /// The maximum difference in seconds between the current time and the webhook timestamp.
        /// Used to verify authenticity of webhook requests and to avoid replay attacks.
        /// </summary>
        public int WebhookVerificationClockSkewThreshold { get; }

        /// <summary>
        /// List of additional scopes to request
        /// </summary>
        public List<string> AdditionalScopes { get; }
    }
}
