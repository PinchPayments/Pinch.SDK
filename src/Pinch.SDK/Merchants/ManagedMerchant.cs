using Newtonsoft.Json;
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

        private string _legalStreetAddress;
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string StreetAddress
        {
            get { return _legalStreetAddress; }
            set { _legalStreetAddress = value; }
        }
        public string LegalStreetAddress
        {
            get { return _legalStreetAddress; }
            set { _legalStreetAddress = value; }
        }

        private string _legalSuburb;
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string Suburb
        {
            get { return _legalSuburb; }
            set { _legalSuburb = value; }
        }
        public string LegalSuburb
        {
            get { return _legalSuburb; }
            set { _legalSuburb = value; }
        }

        private string _legalState;
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string State
        {
            get { return _legalState; }
            set { _legalState = value; }
        }
        public string LegalState
        {
            get { return _legalState; }
            set { _legalState = value; }
        }

        private string _legalPostcode;
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string Postcode
        {
            get { return _legalPostcode; }
            set { _legalPostcode = value; }
        }
        public string LegalPostcode
        {
            get { return _legalPostcode; }
            set { _legalPostcode = value; }
        }

        private string _legalCountry;
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string Country
        {
            get { return _legalCountry; }
            set { _legalCountry = value; }
        }
        public string LegalCountry
        {
            get { return _legalCountry; }
            set { _legalCountry = value; }
        }
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
