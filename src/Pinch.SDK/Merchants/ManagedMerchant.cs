using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Represents a managed merchant entity within the Pinch payment system.
    /// Contains merchant information, address details, bank account details, compliance status, and contact information.
    /// </summary>
    public class ManagedMerchant
    {
        /// <summary>
        /// Gets or sets the unique identifier for the merchant.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the test merchant identifier associated with this merchant.
        /// </summary>
        public string TestMerchantId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this merchant is configured for test transactions only.
        /// </summary>
        public bool TestOnlyMerchant { get; set; }

        /// <summary>
        /// Gets or sets the merchant's company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the legal entity name of the merchant.
        /// </summary>
        public string LegalEntityName { get; set; }

        /// <summary>
        /// Gets or sets the merchant's company email address.
        /// </summary>
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Gets or sets the merchant's company phone number.
        /// </summary>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// Gets or sets the merchant's company website URL.
        /// </summary>
        public string CompanyWebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets the merchant's company registration number.
        /// </summary>
        public string CompanyRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the routing number for the merchant's bank account.
        /// </summary>
        public string BankAccountRoutingNumber { get; set; }

        /// <summary>
        /// Gets or sets the account number for the merchant's bank account.
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the merchant's bank account.
        /// </summary>
        public string BankAccountName { get; set; }

        private string _legalStreetAddress;
        /// <summary>
        /// Gets or sets the legal street address of the merchant.
        /// </summary>
        /// <remarks>
        /// This property is deprecated. Use <see cref="LegalStreetAddress"/> instead.
        /// </remarks>
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string StreetAddress
        {
            get { return _legalStreetAddress; }
            set { _legalStreetAddress = value; }
        }

        /// <summary>
        /// Gets or sets the legal street address of the merchant.
        /// </summary>
        public string LegalStreetAddress
        {
            get { return _legalStreetAddress; }
            set { _legalStreetAddress = value; }
        }

        private string _legalSuburb;
        /// <summary>
        /// Gets or sets the suburb/city of the merchant's legal address.
        /// </summary>
        /// <remarks>
        /// This property is deprecated. Use <see cref="LegalSuburb"/> instead.
        /// </remarks>
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string Suburb
        {
            get { return _legalSuburb; }
            set { _legalSuburb = value; }
        }

        /// <summary>
        /// Gets or sets the suburb/city of the merchant's legal address.
        /// </summary>
        public string LegalSuburb
        {
            get { return _legalSuburb; }
            set { _legalSuburb = value; }
        }

        private string _legalState;
        /// <summary>
        /// Gets or sets the state or province of the merchant's legal address.
        /// </summary>
        /// <remarks>
        /// This property is deprecated. Use <see cref="LegalState"/> instead.
        /// </remarks>
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string State
        {
            get { return _legalState; }
            set { _legalState = value; }
        }

        /// <summary>
        /// Gets or sets the state or province of the merchant's legal address.
        /// </summary>
        public string LegalState
        {
            get { return _legalState; }
            set { _legalState = value; }
        }

        private string _legalPostcode;
        /// <summary>
        /// Gets or sets the postcode or ZIP code of the merchant's legal address.
        /// </summary>
        /// <remarks>
        /// This property is deprecated. Use <see cref="LegalPostcode"/> instead.
        /// </remarks>
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string Postcode
        {
            get { return _legalPostcode; }
            set { _legalPostcode = value; }
        }

        /// <summary>
        /// Gets or sets the postcode or ZIP code of the merchant's legal address.
        /// </summary>
        public string LegalPostcode
        {
            get { return _legalPostcode; }
            set { _legalPostcode = value; }
        }

        private string _legalCountry;
        /// <summary>
        /// Gets or sets the country of the merchant's legal address.
        /// </summary>
        /// <remarks>
        /// This property is deprecated. Use <see cref="LegalCountry"/> instead.
        /// </remarks>
        [JsonIgnore]
        [Obsolete("No longer used. Please use Legal Address.")]
        public string Country
        {
            get { return _legalCountry; }
            set { _legalCountry = value; }
        }

        /// <summary>
        /// Gets or sets the country of the merchant's legal address.
        /// </summary>
        public string LegalCountry
        {
            get { return _legalCountry; }
            set { _legalCountry = value; }
        }

        /// <summary>
        /// Gets or sets the street address for the merchant's trading location.
        /// </summary>
        public string TradingStreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the suburb or city of the merchant's trading address.
        /// </summary>
        public string TradingSuburb { get; set; }

        /// <summary>
        /// Gets or sets the state or province of the merchant's trading address.
        /// </summary>
        public string TradingState { get; set; }

        /// <summary>
        /// Gets or sets the postcode or ZIP code of the merchant's trading address.
        /// </summary>
        public string TradingPostcode { get; set; }

        /// <summary>
        /// Gets or sets the country of the merchant's trading address.
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
        /// Gets or sets the reporting identifier for the merchant.
        /// Used for identifying the merchant in reporting and audit scenarios.
        /// </summary>
        public string ReportingIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the time zone identifier for the merchant (e.g., "Australia/Sydney").
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the nature of the merchant's business.
        /// </summary>
        public string NatureOfBusiness { get; set; }

        /// <summary>
        /// Gets or sets the organization type of the merchant (e.g., "Sole Trader", "Partnership", "Company").
        /// </summary>
        public string OrganisationType { get; set; }

        /// <summary>
        /// Gets or sets the compliance information and status for the merchant.
        /// </summary>
        public Compliance Compliance { get; set; }

        /// <summary>
        /// Gets or sets the collection of contacts associated with the merchant.
        /// </summary>
        public IEnumerable<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Gets or sets the collection of merchant identifiers (such as MCC codes or identifiers used by external systems).
        /// </summary>
        public IEnumerable<MerchantIdentifierDto> MerchantIdentifiers { get; set; } = new List<MerchantIdentifierDto>();
    }
}
