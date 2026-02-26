using System.Net.Http.Headers;

namespace Pinch.SDK.Helpers
{
    public class JwtAuthHeader
    {
        public static AuthenticationHeaderValue GetHeader(string accessToken)
        {
            return new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
