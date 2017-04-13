using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Agreements;
using Pinch.SDK.Auth;
using Pinch.SDK.Events;
using Pinch.SDK.Merchants;
using Pinch.SDK.Payers;
using Pinch.SDK.Payments;
using Pinch.SDK.Transfers;

namespace Pinch.SDK
{
    /// <summary>
    /// The Pinch API. This class is all you need to call every method of our API.
    /// </summary>
    public class PinchApi
    {
        private readonly string _secretKey;
        private readonly string _clientId;
        private readonly string _baseUri;
        private readonly string _authUri;
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

        public AuthClient Auth => _auth ?? (_auth = new AuthClient(_secretKey, _authUri, _baseUri));
        public MerchantClient Merchant => _merchant ?? (_merchant = new MerchantClient(_baseUri, GetAccessToken));
        public PayerClient Payer => _payer ?? (_payer = new PayerClient(_baseUri, GetAccessToken));
        public PaymentClient Payment => _payment ?? (_payment = new PaymentClient(_baseUri, GetAccessToken));
        public TransferClient Transfer => _transfer ?? (_transfer = new TransferClient(_baseUri, GetAccessToken));
        public EventClient Event => _event ?? (_event = new EventClient(_baseUri, GetAccessToken));
        public AgreementClient Agreement => _agreement ?? (_agreement = new AgreementClient(_baseUri, GetAccessToken));

        /// <summary>
        /// Supply your Merchant ID and Secret Key. These can be found in the API Keys menu item in the Pinch Portal.
        /// </summary>
        /// <param name="merchantId">Your Merchant ID</param>
        /// <param name="secretKey">Your Secret Key</param>
        /// <param name="options">Mostly used to set IsLive. There are a few things you can override in here.</param>
        public PinchApi(string merchantId, string secretKey, PinchApiOptions options)
        {
            if (!string.IsNullOrEmpty(options.BaseUri))
            {
                _baseUri = options.BaseUri;
            }
            else
            {
                _baseUri = options.IsLive ? Settings.ApiBaseUri_Production : Settings.ApiBaseUri_Test;
            }

            _authUri = !string.IsNullOrEmpty(options.AuthUri) ? options.AuthUri : Settings.AuthBaseUri_Production;

            _secretKey = secretKey;
            _clientId = merchantId;
            _accessToken = options.AccessToken;
            _refreshToken = options.RefreshToken;
            _applicationId = options.ApplicationId;
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
    }
}
