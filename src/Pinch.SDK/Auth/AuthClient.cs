using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace Pinch.SDK.Auth
{
    public class AuthClient
    {
        private readonly string _apiKey;
        private readonly string _baseUri;
        private readonly RestClient _client;

        public AuthClient(string apiKey, string authUri, string baseUri)
        {
            _apiKey = apiKey;
            _baseUri = baseUri;
            _client = new RestClient(authUri);
        }

        public async Task<GetAccessTokenResponse> GetAccessToken(string code, string clientId, string redirectUri)
        {
            _client.Authenticator = new HttpBasicAuthenticator(clientId, _apiKey);

            var request = new RestRequest("connect/token", Method.POST);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", code);
            request.AddParameter("redirect_uri", redirectUri);

            var response = await _client.ExecuteTaskAsync<GetAccessTokenResponse>(request);

            _client.Authenticator = null;

            return response.Data;
        }

        public async Task<List<GetClaimsResponseItem>> GetClaims(string accessToken)
        {
            var client = new RestClient(_baseUri);
            client.Authenticator = new JwtAuthenticator(accessToken);
            var request = new RestRequest("values/claims", Method.GET);
            var response = await client.ExecuteTaskAsync<List<GetClaimsResponseItem>>(request);

            return response.Data;
        }
    }
}
