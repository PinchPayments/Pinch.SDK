using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Claims;
using IdentityModel.Client;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Auth
{
    /// <summary>
    /// Provides authentication and authorization functionality for the Pinch SDK.
    /// </summary>
    public class AuthClient
    {
        private readonly string _secretKey;
        private readonly string _baseUri;
        private readonly string _authUri;
        private readonly List<string> _additionalScopes;
        private readonly Func<HttpClient> _httpClientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthClient"/> class.
        /// </summary>
        /// <param name="secretKey">The secret key for authentication.</param>
        /// <param name="authUri">The authentication server URI.</param>
        /// <param name="baseUri">The base URI for the API.</param>
        /// <param name="additionalScopes">Additional OAuth scopes to request.</param>
        /// <param name="httpClientFactory">Factory function to create HTTP client instances.</param>
        public AuthClient(string secretKey, string authUri, string baseUri, List<string> additionalScopes, Func<HttpClient> httpClientFactory)
        {
            _secretKey = secretKey;
            _baseUri = baseUri;
            _authUri = authUri;
            _additionalScopes = additionalScopes;

            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Gets the OAuth connect URL for authorization.
        /// </summary>
        /// <param name="applicationId">The application/client identifier.</param>
        /// <param name="redirectUri">The redirect URI after authorization.</param>
        /// <returns>The authorization URL.</returns>
        public string GetConnectUrl(string applicationId, string redirectUri)
        {
            return $"{_authUri}/connect/authorize?client_id={applicationId}&redirect_uri={redirectUri}&response_type=code&scope=api1 offline_access openid";
        }

        /// <summary>
        /// Exchanges an authorization code for an access token.
        /// </summary>
        /// <param name="code">The authorization code.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="redirectUri">The redirect URI used in the authorization request.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the access token response.</returns>
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

        /// <summary>
        /// Gets an access token using client credentials (secret key).
        /// </summary>
        /// <param name="secretKey">The client secret key.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the access token response.</returns>
        public async Task<GetAccessTokenFromSecretKeyResponse> GetAccessTokenFromSecretKey(string secretKey, string clientId)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_authUri)
            };
            client.DefaultRequestHeaders.Authorization = BasicAuthHeader.GetHeader(clientId, secretKey);

            var scopes = new List<string> { "api1" };

            if (_additionalScopes != null && _additionalScopes.Count > 0)
            {
                scopes.AddRange(_additionalScopes);
            }

            var parameters = new Dictionary<string, string>()
            {
                {"grant_type", "client_credentials"},
                {"scope", string.Join(" ", scopes)}
            };

            var clientResponse = await client.PostAsync("connect/token", HttpClientHelpers.GetPostBody(parameters));
            var response = await QuickResponse<GetAccessTokenFromSecretKeyResponse>.FromMessage(clientResponse);            

            if (response.Data?.AccessToken == null)
            {
                throw new Exception($"Could not get access token. Error: {response.ResponseBody}");
            }

            return response.Data;
        }

        /// <summary>
        /// Gets a new access token using a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="secretKey">The client secret key.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the access token response.</returns>
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

        /// <summary>
        /// Gets the user claims associated with an access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of claims.</returns>
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
