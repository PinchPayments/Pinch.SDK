﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class ManagedMerchant
    {
        public string Id { get; set; }

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
        public string Country { get; set; }

        // Primary Contact Information
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Dob { get; set; }
        public string GovernmentNumber { get; set; }
        public string CompanyWebsiteUrl { get; set; }
        public string NatureOfBusiness { get; set; }

        public string TestMerchantId { get; set; }
        public string TestSecretKey { get; set; }
        public string LiveSecretKey { get; set; }
        public string TestPublishableKey { get; set; }
        public string LivePublishableKey { get; set; }
    }
}
