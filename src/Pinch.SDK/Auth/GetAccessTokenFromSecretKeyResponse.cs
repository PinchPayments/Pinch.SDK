using Newtonsoft.Json;

namespace Pinch.SDK.Auth
{
    /// <summary>
    /// Represents the response from getting an access token using a secret key.
    /// </summary>
    public class GetAccessTokenFromSecretKeyResponse
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
        /// Gets or sets the token expiration time in seconds.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
