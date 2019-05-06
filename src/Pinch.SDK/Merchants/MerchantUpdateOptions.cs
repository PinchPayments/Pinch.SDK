using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Merchant and Primary Contact information
    /// </summary>
    public class MerchantUpdateOptions
    {
        // Merchant Information
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Company Email. Meant to be the generic/support company email address.
        /// </summary>
        public string CompanyEmail { get; set; }
        /// <summary>
        /// Company Phone. Meant to be the generic/support company phone number.
        /// </summary>
        public string CompanyPhone { get; set; }
        /// <summary>
        /// Bank Account Name
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// Bank Account BSB (also known as Routing Number)
        /// </summary>
        public string Bsb { get; set; }
        /// <summary>
        /// Bank Account Number
        /// </summary>
        public string AccountNumber { get; set; }        
        /// <summary>
        /// Company ABN (also known as Business Number)
        /// </summary>
        public string Abn { get; set; }
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
        /// This text will appear on the payer's bank statement for each transaction. You usually only have 16 characters, so be brief and identifiable.
        /// </summary>
        public string BankStatementLabel { get; set; }
        /// <summary>
        /// This message will be shown to Payers who are signing up to direct debit or are querying what your business is.
        /// Explain in roughly 1 paragraph who you are and what service you provide.
        /// </summary>
        public string DebitMessage { get; set; }

        // Primary Contact Information
        /// <summary>
        /// The first name of the person responsible for this merchant.
        /// </summary>
        public string ContactFirstName { get; set; }
        /// <summary>
        /// The last name of the person responsible for this merchant.
        /// </summary>
        public string ContactLastName { get; set; }
        /// <summary>
        /// The email address of the person responsible for this merchant.
        /// </summary>
        public string ContactEmail { get; set; }
        /// <summary>
        /// The phone number (preferably mobile) of the person responsible for this merchant.
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// The date of birth of the person responsible for this merchant.
        /// </summary>
        public string Dob { get; set; }
        /// <summary>
        /// The Government ID Number (Passport or Drivers License) of the person responsible for this merchant.
        /// </summary>
        public string GovernmentNumber { get; set; }
    }
}
