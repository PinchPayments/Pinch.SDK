using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using IdentityModel.Client;
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

        public string GetConnectUrl(string applicationId, string redirectUri)
        {
            //https://localhost:44329/connect/authorize?client_id=app_123&redirect_uri=https://localhost:44389/pinch/callback&response_type=code&scope=api1 offline_access
            return $"{_authUri}/connect/authorize?client_id={applicationId}&redirect_uri={redirectUri}&response_type=code&scope=api1 offline_access openid merchant";
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

        public async Task<List<Claim>> GetClaims(string accessToken)
        {
            var discoveryClient = new DiscoveryClient(_authUri);
            var doc = await discoveryClient.GetAsync();
            var userInfoClient = new UserInfoClient(doc.UserInfoEndpoint);
            var response = await userInfoClient.GetAsync(accessToken);

            return response.Claims.ToList();
        }
    }
}
