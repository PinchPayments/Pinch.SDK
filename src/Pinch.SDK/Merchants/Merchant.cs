using System;

namespace Pinch.SDK.Merchants
{
    public class Merchant
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactEmail { get; set; }
        public string Abn { get; set; }
        public string BSB { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string BankStatementLabel { get; set; }
        public string DebitMessage { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
