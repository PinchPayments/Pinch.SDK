using System.Collections.Generic;

namespace Pinch.SDK.Fees
{
    public class FeesCalculateOptions
    {
        public string SourceType { get; set; }
        public string Token { get; set; }
        public string SourceId { get; set; }
        public long Amount { get; set; }
        public long ApplicationFee { get; set; }
        public string Currency { get; set; }
        public List<string> Surcharge { get; set; } = new List<string>();
    }
}
