using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Agreements;
using Pinch.SDK.Auth;
using Pinch.SDK.Events;
using Pinch.SDK.Fees;
using Pinch.SDK.Merchants;
using Pinch.SDK.Payers;
using Pinch.SDK.Payments;
using Pinch.SDK.Plans;
using Pinch.SDK.Refunds;
using Pinch.SDK.Subscriptions;
using Pinch.SDK.Transfers;
using Pinch.SDK.Webhooks;

namespace Pinch.SDK
{
    /// <summary>
    /// The Pinch API. This class is all you need to call every method of our API.
    /// </summary>
    public class PinchApi
    {
        // HttpClient is designed to be reused and is thread safe. 
        // See: https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
        // Create one per instance for easy use, but also accept a Func to receive a properly managed HttpClient instance.        
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Func<HttpClient> _httpClientFactory;

        private readonly PinchApiOptions _options;
        private readonly string _secretKey;
        private readonly string _clientId;
        private readonly string _refreshToken;
        private readonly string _applicationId;
        private string _accessToken;

        private AuthClient _auth;
        private MerchantClient _merchant;
        private PayerClient _payer;
        private PaymentClient _payment;
        private TransferClient _transfer;
        private EventClient _event;
        private AgreementClient _agreement;
        private WebhookClient _webhook;
        private PlanClient _plan;
        private SubscriptionClient _subscription;
        private FeeScheduleClient _feeSchedules;
        private FeesClient _fees;
        private RefundsClient _refunds;

        public AuthClient Auth => _auth ?? (_auth = new AuthClient(_secretKey, _options.AuthUri, _options.BaseUri, _options.AdditionalScopes, HttpClientFactoryOrStaticInstance()));
        public MerchantClient Merchant => _merchant ?? (_merchant = new MerchantClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public PayerClient Payer => _payer ?? (_payer = new PayerClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public PaymentClient Payment => _payment ?? (_payment = new PaymentClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public TransferClient Transfer => _transfer ?? (_transfer = new TransferClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public EventClient Event => _event ?? (_event = new EventClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public AgreementClient Agreement => _agreement ?? (_agreement = new AgreementClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public WebhookClient Webhook => _webhook ?? (_webhook = new WebhookClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public PlanClient Plan => _plan ?? (_plan = new PlanClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public SubscriptionClient Subscriptions => _subscription ?? (_subscription = new SubscriptionClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public FeeScheduleClient FeeSchedules => _feeSchedules ?? (_feeSchedules = new FeeScheduleClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public FeesClient Fees => _fees ?? (_fees = new FeesClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));
        public RefundsClient Refunds => _refunds ?? (_refunds = new RefundsClient(_options, GetAccessToken, HttpClientFactoryOrStaticInstance()));

        /// <summary>
        /// Supply your Merchant ID and Secret Key. These can be found in the API Keys menu item in the Pinch Portal.
        /// </summary>
        /// <param name="merchantId">Your Merchant ID</param>
        /// <param name="secretKey">Your Secret Key</param>
        /// <param name="isLive">Set to false to use the sandbox test system. Set to true to perform live production transactions.</param>
        public PinchApi(string merchantId, string secretKey, bool isLive)
        :this(merchantId, secretKey, new PinchApiOptions() {
            IsLive = isLive
        })
        {
        }

        /// <summary>
        /// Supply your Merchant ID and Secret Key. These can be found in the API Keys menu item in the Pinch Portal.
        /// </summary>
        /// <param name="merchantId">Your Merchant ID</param>
        /// <param name="secretKey">Your Secret Key</param>
        /// <param name="options">Mostly used to set IsLive. There are a few things you can override in here.</param>
        /// <param name="httpClientFactory">A function to get an instance of HttpClient. Use this to manage your own instance or make use of the HttpClientFactory to manage instances for you. If no factory is supplied, an instance is created per PinchApi instance.</param>
        public PinchApi(string merchantId, string secretKey, PinchApiOptions options, Func<HttpClient> httpClientFactory = null)
        {
            _httpClientFactory = httpClientFactory;

            options.ApiVersion = !string.IsNullOrEmpty(options.ApiVersion)
                ? options.ApiVersion
                : Settings.LatestApiVersion;

            if (!string.IsNullOrEmpty(options.BaseUri))
            {
                options.BaseUri = $"{options.BaseUri.TrimEnd('/')}/{(options.IsLive ? "live" : "test")}/";
            }
            else
            {
                options.BaseUri = options.IsLive ? Settings.ApiBaseUri_Production : Settings.ApiBaseUri_Test;
            }
            
            options.AuthUri = !string.IsNullOrEmpty(options.AuthUri) ? options.AuthUri : Settings.AuthBaseUri_Production;

            _secretKey = secretKey;
            _clientId = merchantId;
            _accessToken = options.AccessToken;
            _refreshToken = options.RefreshToken;
            _applicationId = options.ApplicationId;
            _options = options;
        }

        /// <summary>
        /// This method fetches and caches an Access Token, requested from the Auth API.
        /// </summary>
        /// <param name="renew">Set to <c>true</c> to force a new token to be fetched, rather than using the cache.</param>
        /// <returns></returns>
        protected async Task<string> GetAccessToken(bool renew = false)
        {
            if (_accessToken == null || renew)
            {
                if (!string.IsNullOrEmpty(_refreshToken))
                {
                    var result = await Auth.GetAccessTokenFromRefreshToken(_refreshToken, _secretKey, _applicationId);
                    _accessToken = result.AccessToken;
                }
                else
                {
                    var result = await Auth.GetAccessTokenFromSecretKey(_secretKey, _clientId);
                    _accessToken = result.AccessToken;
                }
            }

            return _accessToken;
        }

        /// <summary>
        /// Returns either the given HttpClientFactory or a default implementation.
        /// </summary>
        /// <returns></returns>
        protected Func<HttpClient> HttpClientFactoryOrStaticInstance()
        {
            return _httpClientFactory ?? (() => _httpClient);
        }
    }
}
