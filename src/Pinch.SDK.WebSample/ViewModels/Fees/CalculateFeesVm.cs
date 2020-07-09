using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Fees;

namespace Pinch.SDK.WebSample.ViewModels.Fees
{
    public class CalculateFeesVm
    {
        public string PublishableKey { get; set; }
        public string BaseApiUrl { get; set; }

        public string Token { get; set; }
        public string SourceId { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public bool Surcharge { get; set; }

        public FeesCalculation FeesCalculation { get; set; }
    }
}
