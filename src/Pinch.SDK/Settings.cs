using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK
{
    /// <summary>
    /// Some constants containing the default settings for Pinch.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// The Base URI for the Pinch API - Test Endpoint
        /// </summary>
        public const string ApiBaseUri_Test = "https://api.getpinch.com.au/test/";
        /// <summary>
        /// The Base URI for the Pinch API - Live Endpoint
        /// </summary>
        public const string ApiBaseUri_Production = "https://api.getpinch.com.au/live/";
        /// <summary>
        /// The Base URI for the Pinch Authentication Server
        /// </summary>
        public const string AuthBaseUri_Production = "https://auth.getpinch.com.au";
        /// <summary>
        /// The current latest API version. This is included as a header in all API calls.
        /// </summary>
        public const string LatestApiVersion = "2019.1";
    }
}
