using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
