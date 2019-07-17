using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace Pinch.SDK.Webhooks
{
    public interface IWebhookClient
    {
        Task<ApiResponse<Webhook>> Save(WebhookSaveOptions options);
        Task<ApiResponse<List<Webhook>>> GetWebhooks();
        bool VerifyWebhook(string webhookSecret, string requestBody, IDictionary<string, StringValues> headers);
    }
}