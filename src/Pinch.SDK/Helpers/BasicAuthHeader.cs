using System;
using System.Net.Http.Headers;

namespace Pinch.SDK.Helpers
{
    /// <summary>
    /// Provides helper methods for creating HTTP Basic Authentication headers.
    /// </summary>
    public static class BasicAuthHeader
    {
        /// <summary>
        /// Creates an HTTP Basic Authentication header value from the provided credentials.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        /// <returns>
        /// An <see cref="AuthenticationHeaderValue"/> containing the Base64-encoded credentials
        /// ready to be used in an HTTP Authorization header.
        /// </returns>
        /// <remarks>
        /// This method encodes the username and password as a Base64 string in the format "username:password"
        /// according to the HTTP Basic Authentication specification (RFC 7617). The resulting header value
        /// can be directly applied to HTTP requests that require Basic authentication.
        /// </remarks>
        /// <example>
        /// <code>
        /// var authHeader = BasicAuthHeader.GetHeader("user@example.com", "mypassword");
        /// client.DefaultRequestHeaders.Authorization = authHeader;
        /// </code>
        /// </example>
        public static AuthenticationHeaderValue GetHeader(string username, string password)
        {
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{username}:{password}")));
        }
    }
}
