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
            return $"{_authUri}/connect/authorize?client_id={applicationId}&redirect_uri={redirectUri}&response_type=code&scope=api1 offline_access openid";
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

            var clientResponse = await client.PostAsync("connect/token", HttpClientHelpers.GetPostBody(parameters));
            var response = await QuickResponse<GetAccessTokenFromSecretKeyResponse>.FromMessage(clientResponse);            

            if (response.Data?.AccessToken == null)
            {
                throw new Exception($"Could not get access token. Error: {response.ResponseBody}");
            }

            return response.Data;
        }

        public async Task<GetAccessTokenFromRefreshTokenResponse> GetAccessTokenFromRefreshToken(string refreshToken, string secretKey, string clientId)
        {
            var disco = await DiscoveryClient.GetAsync(_authUri);
            if (disco.IsError) throw new Exception(disco.Error);

            var tokenClient = new TokenClient(disco.TokenEndpoint, clientId, secretKey);
            var tokenResult = await tokenClient.RequestRefreshTokenAsync(refreshToken);

            return new GetAccessTokenFromRefreshTokenResponse()
            {
                AccessToken = tokenResult.AccessToken,
                RefreshToken = tokenResult.RefreshToken,
                ExpiresIn = tokenResult.ExpiresIn,
                TokenType = tokenResult.TokenType,
            };
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
