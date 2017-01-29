using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK
{
    public class PinchApiOptions
    {
        public bool IsLive { get; set; }
        public string BaseUri { get; set; }
        public string AuthUri { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string ApplicationId { get; set; }
    }
}
