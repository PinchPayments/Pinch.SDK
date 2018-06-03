using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class ManagedMerchantCreateOptions
    {
        // Merchant Information
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string AccountName { get; set; }
        public string Bsb { get; set; }
        public string AccountNumber { get; set; }        
        public string Abn { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }

        // Primary Contact Information
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Dob { get; set; }
        public string GovernmentNumber { get; set; }

        // Deprecated fields (Delete once version is no longer used).
        public string Email => CompanyEmail; // Paul only (2018-05-24).
    }
}
