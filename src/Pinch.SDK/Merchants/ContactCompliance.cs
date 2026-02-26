using System.Collections.Generic;

namespace Pinch.SDK.Merchants
{
    public class ContactCompliance
    {
        public string ContactId { get; set; }
        public string OverallStatus { get; set; }
        public string DocumentVerificationStatus { get; set; }
        public string IdentityVerificationStatus { get; set; }
        public string EmailVerificationStatus { get; set; }
        public string PhoneVerificationStatus { get; set; }
        public IList<Document> Documents { get; set; } = new List<Document>();
    }
}
