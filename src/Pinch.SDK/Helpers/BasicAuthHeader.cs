using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pinch.SDK.Helpers
{
    public static class BasicAuthHeader
    {
        public static AuthenticationHeaderValue GetHeader(string username, string password)
        {
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{username}:{password}")));
        }
    }
}
