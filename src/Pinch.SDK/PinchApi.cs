using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Auth;

namespace Pinch.SDK
{
    public class PinchApi
    {
        private readonly string _apiKey;
        private readonly string _baseUri;
        private readonly string _authUri;
        private AuthClient _auth;

        public PinchApi(string apiKey)
            : this(apiKey, Settings.ApiBaseUri_Production, Settings.AuthBaseUri_Production)
        {
        }

        public PinchApi(string apiKey, string baseUri)
            : this(apiKey, baseUri, Settings.AuthBaseUri_Production)
        {
        }

        public PinchApi(string apiKey, string baseUri, string authUri)
        {
            _apiKey = apiKey;
            _baseUri = baseUri;
            _authUri = authUri;
        }

        public AuthClient Auth => _auth ?? (_auth = new AuthClient(_apiKey, _authUri, _baseUri));
    }
}
