using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Auth;
using Pinch.SDK.Merchant;

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

        public PinchApi(string secretKey, string clientId)
            : this(secretKey, clientId, Settings.ApiBaseUri_Production, Settings.AuthBaseUri_Production)
        {
        }

        public PinchApi(string secretKey, string clientId, string baseUri)
            : this(secretKey, clientId, baseUri, Settings.AuthBaseUri_Production)
        {
        }

        public PinchApi(string secretKey, string clientId, string baseUri, string authUri)
        {
            _secretKey = secretKey;
            _baseUri = baseUri;
            _authUri = authUri;
            _clientId = clientId;
        }

        public AuthClient Auth => _auth ?? (_auth = new AuthClient(_secretKey, _authUri, _baseUri));
        public MerchantClient Merchant => _merchant ?? (_merchant = new MerchantClient(_baseUri, GetAccessToken));

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
