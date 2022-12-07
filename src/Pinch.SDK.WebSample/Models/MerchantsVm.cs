using Newtonsoft.Json;
using Pinch.SDK.Merchants;

namespace Pinch.SDK.WebSample.Models
{
    public class MerchantsVm
    {
        public Merchant MyMerchant { get; set; }
        public string MyMerchantJson => JsonConvert.SerializeObject(MyMerchant, Formatting.Indented);
        public IEnumerable<ManagedMerchant> ManagedMerchants { get; set; } = new List<ManagedMerchant>();
        public string ImpersonatedMerchantId { get; set; }
    }
}
