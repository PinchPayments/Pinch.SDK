using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinch.SDK.Customers
{
    /// <summary>
    /// Represents a user of the customer portal
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer User Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Verified Email Address
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Verified PHone Number (mobile phone only)
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Confirms whether email has been verified successfully
        /// </summary>
        public bool EmailVerified { get; set; }
        /// <summary>
        /// Confirms whether phone number has been verified successfully
        /// </summary>
        public bool PhoneVerified { get; set; }

        /// <summary>
        /// A list of connected MerchantIDs
        /// </summary>
        public List<string> ConnectedMerchants { get; set; }
    }
}
