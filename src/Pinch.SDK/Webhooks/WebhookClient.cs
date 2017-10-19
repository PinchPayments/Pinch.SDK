using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace Pinch.SDK.Webhooks
{
    public class WebhookClient: BaseClient
    {
        private readonly PinchApiOptions _options;

        public WebhookClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken)
            : base(options.BaseUri, getAccessToken)
        {
            _options = options;
        }

        public bool VerifyWebhook(string webhookSecret, string requestBody, IDictionary<string, StringValues> headers)
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
            if (Math.Abs((DateTimeOffset.UtcNow - timeOffset).TotalSeconds) > _options.WebhookVerificationClockSkewThreshold)
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
