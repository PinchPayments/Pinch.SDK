using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class UpdateMerchantComplianceOptions
    {
        public List<MerchantCompliancePrePaymentRiskOptions> PrePaymentRiskResponses { get; set; }
    }
    
    public class MerchantCompliancePrePaymentRiskOptions
    {
        public string Code { get; set; }
        public string Answer { get; set; }
    }
}
