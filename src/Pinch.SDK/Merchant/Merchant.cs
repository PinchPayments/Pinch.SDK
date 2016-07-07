using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchant
{
    public class Merchant
    {
        public int MerchantId { get; set; }
        public string CompanyName { get; set; }
        public string ContactEmail { get; set; }
        public string Bsb { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
    }
}
