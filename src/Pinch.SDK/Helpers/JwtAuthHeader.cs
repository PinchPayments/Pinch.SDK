using System.Net.Http.Headers;

namespace Pinch.SDK.Helpers
{
    /// <summary>
    /// Provides helper methods for creating JWT Bearer authentication headers.
    /// </summary>
    public class JwtAuthHeader
    {
        /// <summary>
        /// Creates an authentication header with the Bearer scheme using the specified access token.
        /// </summary>
        /// <param name="accessToken">The JWT access token to include in the authentication header.</param>
        /// <returns>An <see cref="AuthenticationHeaderValue"/> configured with the Bearer scheme and the provided access token.</returns>
        public static AuthenticationHeaderValue GetHeader(string accessToken)
        {
            return new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
