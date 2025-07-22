using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class ManagedMerchant
    {
        public string Id { get; set; }
        public string TestMerchantId { get; set; }
        public bool TestOnlyMerchant { get; set; }

        // Merchant Information
        public string CompanyName { get; set; }
        public string LegalEntityName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyWebsiteUrl { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string BankAccountRoutingNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string TradingStreetAddress { get; set; }
        public string TradingSuburb { get; set; }
        public string TradingState { get; set; }
        public string TradingPostcode { get; set; }
        public string TradingCountry { get; set; }
        public string BankStatementLabel { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string LogoUrl { get; set; }
        public string ReportingIdentifier { get; set; }
        public string TimeZone { get; set; }

        // Compliance Information
        public string NatureOfBusiness { get; set; }
        public string OrganisationType { get; set; }

        //Compliance Status
        public Compliance Compliance { get; set; }

        public IEnumerable<Contact> Contacts { get; set; } = new List<Contact>();
        public IEnumerable<MerchantIdentifierDto> MerchantIdentifiers { get; set; } = new List<MerchantIdentifierDto>();
    }
}
