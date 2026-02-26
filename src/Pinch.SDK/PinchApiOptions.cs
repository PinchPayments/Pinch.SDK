using System.Collections.Generic;

namespace Pinch.SDK
{
    /// <summary>
    /// Configuration options for the Pinch API client.
    /// </summary>
    public class PinchApiOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PinchApiOptions"/> class.
        /// </summary>
        /// <param name="isLive">Indicates whether to use the live or test environment. Defaults to false (test).</param>
        /// <param name="baseUri">Optional custom base URI for the API.</param>
        /// <param name="authUri">Optional custom authentication URI.</param>
        /// <param name="accessToken">The access token for authentication.</param>
        /// <param name="refreshToken">The refresh token for obtaining new access tokens.</param>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="impersonateMerchantId">Optional merchant ID to impersonate.</param>
        /// <param name="webhookVerificationClockSkewThreshold">Maximum time difference in seconds for webhook verification. Defaults to 300 seconds (5 minutes).</param>
        /// <param name="additionalScopes">Optional list of additional OAuth scopes to request.</param>
        public PinchApiOptions(
            bool? isLive = null,
            string baseUri = null,
            string authUri = null,
            string accessToken = null,
            string refreshToken = null,
            string applicationId = null,
            string impersonateMerchantId = null,
            int? webhookVerificationClockSkewThreshold = null,
            List<string> additionalScopes = null)
        {
            IsLive = isLive ?? false;
           
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
        
        /// <summary>
        /// Gets a value indicating whether the live or test environment is being used.
        /// </summary>
        public bool IsLive { get; }
        
        /// <summary>
        /// Gets the base URI for API requests.
        /// </summary>
        public string BaseUri { get; }
        
        /// <summary>
        /// Gets the authentication URI.
        /// </summary>
        public string AuthUri { get; }
        
        /// <summary>
        /// Gets the access token for authentication.
        /// </summary>
        public string AccessToken { get; }
        
        /// <summary>
        /// Gets the refresh token for obtaining new access tokens.
        /// </summary>
        public string RefreshToken { get; }
        
        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        public string ApplicationId { get; }

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
