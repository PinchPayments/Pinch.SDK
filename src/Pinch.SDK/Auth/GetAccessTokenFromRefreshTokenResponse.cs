using Newtonsoft.Json;

namespace Pinch.SDK.Auth
{
    /// <summary>
    /// Represents the response from a refresh token authentication request.
    /// </summary>
    public class GetAccessTokenFromRefreshTokenResponse
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the number of seconds until the token expires.
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
