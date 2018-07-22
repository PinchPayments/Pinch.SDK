using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pinch.SDK.Merchants;

namespace Pinch.SDK.WebSample.Models
{
    public class MerchantsVm
    {
        public Merchant MyMerchant { get; set; }
        public IEnumerable<ManagedMerchant> ManagedMerchants { get; set; }
        public string ImpersonatedMerchantId { get; set; }
    }
}
