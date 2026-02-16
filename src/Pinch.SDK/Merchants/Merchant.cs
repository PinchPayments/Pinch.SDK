using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pinch.SDK.Merchants
{
    public class Merchant
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
       
        public string LegalStreetAddress
        {
            get { return _legalStreetAddress; }
            set { _legalStreetAddress = value; }
        }

        private string _legalSuburb;
      
        public string LegalSuburb
        {
            get { return _legalSuburb; }
            set { _legalSuburb = value; }
        }

        private string _legalState;
       
        public string LegalState
        {
            get { return _legalState; }
            set { _legalState = value; }
        }

        private string _legalPostcode;
       
        public string LegalPostcode
        {
            get { return _legalPostcode; }
            set { _legalPostcode = value; }
        }

        private string _legalCountry;
       
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

        public IList<MerchantIdentifierDto> MerchantIdentifiers { get; set; } = new List<MerchantIdentifierDto>();
    }
}
