using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class ManagedMerchantCreateOptions
    {
        // Merchant Information
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// The name of your legal entity
        /// </summary>
        public string LegalEntityName { get; set; }
        /// <summary>
        /// Company Email. Meant to be the generic/support company email address.
        /// </summary>
        public string CompanyEmail { get; set; }
        /// <summary>
        /// Company Phone. Meant to be the generic/support company phone number.
        /// </summary>
        public string CompanyPhone { get; set; }
        /// <summary>
        /// The primary website of the business. Can be a social media profile such as Facebook or LinkedIn
        /// </summary>
        public string CompanyWebsiteUrl { get; set; }
        /// <summary>
        /// Company Registration Number (known as ABN in Australia)
        /// </summary>
        public string CompanyRegistrationNumber { get; set; }
        /// <summary>
        /// Bank Account Name
        /// </summary>
        public string BankAccountName { get; set; }
        /// <summary>
        /// Bank Account BSB (also known as Routing Number)
        /// </summary>
        public string BankAccountRoutingNumber { get; set; }
        /// <summary>
        /// Bank Account Number
        /// </summary>
        public string BankAccountNumber { get; set; }
        /// <summary>
        /// Company Address - Street
        /// </summary>
        public string StreetAddress { get; set; }
        /// <summary>
        /// Company Address - Suburb
        /// </summary>
        public string Suburb { get; set; }
        /// <summary>
        /// Company Address - State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Company Address - Postcode (also known as Zip Code)
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// The two digit country code for the country where this merchant is legally established.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// This text will appear on the payer's bank statement for each transaction. You usually only have 16 characters, so be brief and identifiable.
        /// </summary>
        public string BankStatementLabel { get; set; }
        /// <summary>
        /// A description of the business, how/why it takes payment, and an example of the service or goods provided
        /// </summary>
        public string NatureOfBusiness { get; set; }
        /// <summary>
        /// Can be 'company' or 'individual'.
        /// </summary>
        public string OrganisationType { get; set; }
        /// <summary>
        /// You can optionally supply notes for our compliance team to read. Useful for back and forth dialog.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// A list of the relevant business owners or executives for this account (used for compliance and administration)
        /// </summary>
        public List<ContactSaveOptions> Contacts { get; set; } = new List<ContactSaveOptions>();

        // Compliance Info
        /// <summary>
        /// The IP Address of the user creating this new merchant. Ensure this is the end-user and not your server's IP Address.
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// The User Agent string of the user creating this new merchant. Ensure this is the end-user and not your server's User Agent string.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Optional list of Identifiers for the Merchant in external providers.
        /// </summary>
        public List<ManagedMerchantIdentifierOptions> MerchantIdentifiers { get; set; } = new List<ManagedMerchantIdentifierOptions>();

        /// <summary>
        /// Reporting Identifier to display on Daily Statements and Monthly Invoices
        /// </summary>
        public string ReportingIdentifier { get; set; }
    }
}
