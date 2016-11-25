using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class ManagedMerchantCreateOptions
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }

        public string BSB { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }

        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
    }
}
