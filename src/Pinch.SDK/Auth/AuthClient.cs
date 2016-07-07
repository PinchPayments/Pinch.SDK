using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Auth
{
    public class AuthClient
    {
        private readonly string _secretKey;
        private readonly string _baseUri;
        private readonly string _authUri;

        public AuthClient(string secretKey, string authUri, string baseUri)
        {
            _secretKey = secretKey;
            _baseUri = baseUri;
            _authUri = authUri;
        }

        public async Task<GetAccessTokenFromCodeResponse> GetAccessTokenFromCode(string code, string clientId, string redirectUri)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_authUri)
            };
            client.DefaultRequestHeaders.Authorization = BasicAuthHeader.GetHeader(clientId, _secretKey);

            var parameters = new Dictionary<string, string>()
            {
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", redirectUri}
            };

            var response = await client.Post<GetAccessTokenFromCodeResponse>("connect/token", parameters);

            return response.Data;
        }

        public async Task<GetAccessTokenFromSecretKeyResponse> GetAccessTokenFromSecretKey(string secretKey, string clientId)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_authUri)
            };
            client.DefaultRequestHeaders.Authorization = BasicAuthHeader.GetHeader(clientId, secretKey);

            var parameters = new Dictionary<string, string>()
            {
                {"grant_type", "client_credentials"},
                {"scope", "api1"}
            };            

            var response = await client.Post<GetAccessTokenFromSecretKeyResponse>("connect/token", parameters);            
                
            if (response.Data?.AccessToken == null)
            {
                throw new Exception($"Could not get access token. Error: {response.ResponseBody}");
            }

            return response.Data;
        }

        public async Task<List<GetClaimsResponseItem>> GetClaims(string accessToken)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_baseUri)
            };

            client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(accessToken);

            var response = await client.Get<List<GetClaimsResponseItem>>("values/claims");

            return response.Data;
        }
    }
}
