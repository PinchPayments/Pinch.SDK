using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Auth;
using Pinch.SDK.Merchant;
using Pinch.SDK.Payer;
using Pinch.SDK.Payment;

namespace Pinch.SDK
{
    public class PinchApi
    {
        private readonly string _secretKey;
        private readonly string _clientId;
        private readonly string _baseUri;
        private readonly string _authUri;
        private string _accessToken;

        private AuthClient _auth;
        private MerchantClient _merchant;
        private PayerClient _payer;
        private PaymentClient _payment;

        public PinchApi(string secretKey, string clientId, bool isLive = true, string baseUri = null, string authUri = null)
        {
            if (!string.IsNullOrEmpty(baseUri))
            {
                _baseUri = baseUri;
            }
            else
            {
                _baseUri = isLive ? Settings.ApiBaseUri_Production : Settings.ApiBaseUri_Test;
            }

            _authUri = !string.IsNullOrEmpty(authUri) ? authUri : Settings.AuthBaseUri_Production;

            _secretKey = secretKey;
            _clientId = clientId;
        }

        public AuthClient Auth => _auth ?? (_auth = new AuthClient(_secretKey, _authUri, _baseUri));
        public MerchantClient Merchant => _merchant ?? (_merchant = new MerchantClient(_baseUri, GetAccessToken));
        public PayerClient Payer => _payer ?? (_payer = new PayerClient(_baseUri, GetAccessToken));
        public PaymentClient Payment => _payment ?? (_payment = new PaymentClient(_baseUri, GetAccessToken));

        protected async Task<string> GetAccessToken()
        {
            if (_accessToken == null)
            {
                var result = await Auth.GetAccessTokenFromSecretKey(_secretKey, _clientId);
                _accessToken = result.AccessToken;
            }

            return _accessToken;
        }
    }
}
