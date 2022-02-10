using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Merchants
{
    public class ContactSaveOptions
    {
        public string Id { get; set; }
        public bool IsPrimaryContact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string Dob { get; set; }
        public string GovernmentNumber { get; set; }
        public string ContactType { get; set; }
        public decimal? Ownership { get; set; }
        public string JobTitle { get; set; }
    }
}
