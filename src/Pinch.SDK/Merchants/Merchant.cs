using System;
using System.Collections.Generic;

namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Represents a merchant entity in the Pinch SDK.
    /// Contains merchant identification, business information, compliance status, and address details.
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// Gets or sets the unique identifier for the merchant.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the test merchant identifier associated with this merchant for testing purposes.
        /// </summary>
        public string TestMerchantId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this merchant is only available for testing.
        /// </summary>
        public bool TestOnlyMerchant { get; set; }

        /// <summary>
        /// Gets or sets the official company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the legal entity name of the merchant.
        /// </summary>
        public string LegalEntityName { get; set; }

        /// <summary>
        /// Gets or sets the company's contact email address.
        /// </summary>
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Gets or sets the company's contact phone number.
        /// </summary>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// Gets or sets the URL of the company's website.
        /// </summary>
        public string CompanyWebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets the company's registration number (e.g., ABN, ACN for Australian entities).
        /// </summary>
        public string CompanyRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the bank account routing number for the merchant's account.
        /// </summary>
        public string BankAccountRoutingNumber { get; set; }

        /// <summary>
        /// Gets or sets the bank account number for the merchant's account.
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the bank account.
        /// </summary>
        public string BankAccountName { get; set; }

        private string _legalStreetAddress;

        /// <summary>
        /// Gets or sets the street address for the merchant's legal address.
        /// </summary>
        public string LegalStreetAddress
        {
            get { return _legalStreetAddress; }
            set { _legalStreetAddress = value; }
        }

        private string _legalSuburb;

        /// <summary>
        /// Gets or sets the suburb (suburb/locality) for the merchant's legal address.
        /// </summary>
        public string LegalSuburb
        {
            get { return _legalSuburb; }
            set { _legalSuburb = value; }
        }

        private string _legalState;

        /// <summary>
        /// Gets or sets the state or province for the merchant's legal address.
        /// </summary>
        public string LegalState
        {
            get { return _legalState; }
            set { _legalState = value; }
        }

        private string _legalPostcode;

        /// <summary>
        /// Gets or sets the postcode or postal code for the merchant's legal address.
        /// </summary>
        public string LegalPostcode
        {
            get { return _legalPostcode; }
            set { _legalPostcode = value; }
        }

        private string _legalCountry;

        /// <summary>
        /// Gets or sets the country for the merchant's legal address.
        /// </summary>
        public string LegalCountry
        {
            get { return _legalCountry; }
            set { _legalCountry = value; }
        }

        /// <summary>
        /// Gets or sets the street address for the merchant's trading address.
        /// </summary>
        public string TradingStreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the suburb (suburb/locality) for the merchant's trading address.
        /// </summary>
        public string TradingSuburb { get; set; }

        /// <summary>
        /// Gets or sets the state or province for the merchant's trading address.
        /// </summary>
        public string TradingState { get; set; }

        /// <summary>
        /// Gets or sets the postcode or postal code for the merchant's trading address.
        /// </summary>
        public string TradingPostcode { get; set; }

        /// <summary>
        /// Gets or sets the country for the merchant's trading address.
        /// </summary>
        public string TradingCountry { get; set; }

        /// <summary>
        /// Gets or sets the label that appears on the merchant's bank statements.
        /// </summary>
        public string BankStatementLabel { get; set; }

        /// <summary>
        /// Gets or sets the date and time (in UTC) when the merchant was created.
        /// </summary>
        public DateTime CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the URL to the merchant's logo image.
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the reporting identifier for the merchant used in financial reporting and analytics.
        /// </summary>
        public string ReportingIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the time zone identifier for the merchant (e.g., "Australia/Sydney").
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets a description of the merchant's nature of business.
        /// </summary>
        public string NatureOfBusiness { get; set; }

        /// <summary>
        /// Gets or sets the type of organisation the merchant represents (e.g., "Sole Trader", "Company").
        /// </summary>
        public string OrganisationType { get; set; }

        /// <summary>
        /// Gets or sets the compliance information and status for the merchant.
        /// </summary>
        public Compliance Compliance { get; set; }

        /// <summary>
        /// Gets or sets the list of merchant identifiers associated with this merchant.
        /// </summary>
        public IList<MerchantIdentifierDto> MerchantIdentifiers { get; set; } = new List<MerchantIdentifierDto>();
    }
}
