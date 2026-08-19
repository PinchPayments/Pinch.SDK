using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Webhooks
{
    /// <summary>
    /// Client for managing webhooks in the Pinch API
    /// </summary>
    public class WebhookClient: BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookClient"/> class
        /// </summary>
        /// <param name="options">The Pinch API options</param>
        /// <param name="getAccessToken">Function to retrieve an access token</param>
        /// <param name="httpClientFactory">Factory to create HTTP client instances</param>
        public WebhookClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Saves a webhook configuration
        /// </summary>
        /// <param name="options">The webhook save options</param>
        /// <returns>An API response containing the saved webhook</returns>
        public async Task<ApiResponse<Webhook>> Save(WebhookSaveOptions options)
        {
            var response = await PostHttp<Webhook>("webhooks", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Retrieves all configured webhooks
        /// </summary>
        /// <returns>An API response containing the list of webhooks</returns>
        public async Task<ApiResponse<List<Webhook>>> GetWebhooks()
        {
            var response = await GetHttp<List<Webhook>>($"webhooks");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Calls the "Delete WebHook" endpoint https://docs.getpinch.com.au/reference/delete-webhook
        /// </summary>
        /// <param name="id">The ID of the webhook to delete</param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteWebhook(string id)
        {
            var response = await DeleteHttp($"webhooks/{id}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Verifies the authenticity of a webhook request using the Pinch signature
        /// </summary>
        /// <param name="webhookSecret">The webhook secret key for verification</param>
        /// <param name="requestBody">The raw request body</param>
        /// <param name="headers">The request headers containing the Pinch-Signature header</param>
        /// <returns>True if the webhook signature is valid; otherwise, false</returns>
        public bool VerifyWebhook(string webhookSecret, string requestBody, IDictionary<string, string[]> headers)
        {
            var header = headers
                .Where(x => x.Key.ToLower() == "pinch-signature")
                .Select(x => x.Value.FirstOrDefault())
                .FirstOrDefault();

            if (header == null)
            {
                return false;
            }

            var split = header.Split(',');

            // We need at least one signature and also the time.
            if (split.Length < 2)
            {
                return false;
            }

            var time = split.FirstOrDefault(x => x.StartsWith("t="));

            if (time == null)
            {
                return false;
            }

            // Time must be within tolerance
            var seconds = long.Parse(time.Replace("t=", ""));
            var timeOffset = new DateTimeOffset(seconds * 10000000L + 621355968000000000L, TimeSpan.Zero);
            if (Math.Abs((DateTimeOffset.UtcNow - timeOffset).TotalSeconds) > Options.WebhookVerificationClockSkewThreshold)
            {                
                return false;
            }            

            var signatures = split.Where(x => x.StartsWith("v2="));
            var reconstructedSig = CreateSignature(webhookSecret, seconds.ToString(), requestBody);

            return signatures.Any(x => x.Replace("v2=", "") == reconstructedSig);
        }

        private string CreateSignature(string key, string timestamp, string message)
        {
            var payload = $"{timestamp}.{message}";

            var keybytes = Encoding.UTF8.GetBytes(key);
            string hashString;
            using (var hmac = new HMACSHA256(keybytes))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }

            return hashString;
        }
    }
}
