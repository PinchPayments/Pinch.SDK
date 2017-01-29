using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Auth;
using Pinch.SDK.Events;
using Pinch.SDK.Merchants;
using Pinch.SDK.Payers;
using Pinch.SDK.Payments;
using Pinch.SDK.Transfers;

namespace Pinch.SDK
{
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

        public AuthClient Auth => _auth ?? (_auth = new AuthClient(_secretKey, _authUri, _baseUri));
        public MerchantClient Merchant => _merchant ?? (_merchant = new MerchantClient(_baseUri, GetAccessToken));
        public PayerClient Payer => _payer ?? (_payer = new PayerClient(_baseUri, GetAccessToken));
        public PaymentClient Payment => _payment ?? (_payment = new PaymentClient(_baseUri, GetAccessToken));
        public TransferClient Transfer => _transfer ?? (_transfer = new TransferClient(_baseUri, GetAccessToken));
        public EventClient Event => _event ?? (_event = new EventClient(_baseUri, GetAccessToken));

        public PinchApi(string clientId, string secretKey, PinchApiOptions options)
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
            _clientId = clientId;
            _accessToken = options.AccessToken;
            _refreshToken = options.RefreshToken;
            _applicationId = options.ApplicationId;
        }

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
