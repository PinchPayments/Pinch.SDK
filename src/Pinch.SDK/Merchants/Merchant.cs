using System;

namespace Pinch.SDK.Merchants
{
    public class Merchant
    {
        public string Id { get; set; }

        // Merchant Information
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string Abn { get; set; }
        public string Bsb { get; set; }
        public string AccountNumber { get; set; }        
        public string AccountName { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string BankStatementLabel { get; set; }
        public string DebitMessage { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        // Primary Contact Information
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public string TestMerchantId { get; set; }
        public string LivePublishableKey { get; set; }
        public string TestPublishableKey { get; set; }
    }
}
