using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class MerchantCompliance
    {
        public List<MerchantCompliancePrePaymentRisk> PrePaymentRiskResponses { get; set; }
    }

    public class MerchantCompliancePrePaymentRisk
    {
        public string Code { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
    }
}
