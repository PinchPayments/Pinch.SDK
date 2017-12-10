using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.WebSample.Helpers
{
    public class PinchSettings
    {
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }
        public string MerchantId { get; set; }
        public string ApplicationId { get; set; }
        public string BaseUri { get; set; }
        public string AuthUri { get; set; }
    }
}
