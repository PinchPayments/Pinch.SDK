using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace Pinch.SDK.Merchant
{
    public class MerchantClient
    {
        private readonly RestClient _client;
        private readonly Func<Task<string>> _getAccessToken; 

        public MerchantClient(string baseUri, Func<Task<string>> getAccessToken)
        {
            _getAccessToken = getAccessToken;
            _client = new RestClient(baseUri);
        }

        public async Task GetMerchant()
        {
            var token = await _getAccessToken();
            _client.Authenticator = new JwtAuthenticator(token);

            var request = new RestRequest("merchants", Method.GET);

            var response = await _client.ExecuteTaskAsync(request);
        }
    }

}
