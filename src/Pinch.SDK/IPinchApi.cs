using Pinch.SDK.Agreements;
using Pinch.SDK.Auth;
using Pinch.SDK.Events;
using Pinch.SDK.Merchants;
using Pinch.SDK.Payers;
using Pinch.SDK.Payments;
using Pinch.SDK.Transfers;
using Pinch.SDK.Webhooks;

namespace Pinch.SDK
{
    public interface IPinchApi
    {
        IAuthClient Auth { get; }
        IMerchantClient Merchant { get; }
        IPayerClient Payer { get; }
        IPaymentClient Payment { get; }
        ITransferClient Transfer { get; }
        IEventClient Event { get; }
        IAgreementClient Agreement { get; }
        IWebhookClient Webhook { get; }
    }
}