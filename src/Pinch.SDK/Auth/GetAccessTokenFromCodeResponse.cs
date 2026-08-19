using Newtonsoft.Json;

namespace Pinch.SDK.Auth
{
    /// <summary>
    /// Represents the response from an OAuth2 access token request using an authorization code.
    /// </summary>
    public class GetAccessTokenFromCodeResponse
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        
        /// <summary>
        /// Gets or sets the token type (typically "Bearer").
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        
        /// <summary>
        /// Gets or sets the refresh token used to obtain new access tokens.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        
        /// <summary>
        /// Gets or sets the number of seconds until the access token expires.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        
        /// <summary>
        /// Gets or sets the ID token containing user identity information.
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
}
