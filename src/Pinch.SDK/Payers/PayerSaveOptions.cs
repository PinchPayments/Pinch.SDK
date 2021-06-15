using System.ComponentModel;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Payers
{
    /// <summary>
    /// Payer Information
    /// </summary>
    public class PayerSaveOptions
    {
        /// <summary>
        /// Payer ID. Leave blank to create a new Payer.
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
        /// Email Address
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Mobile Number
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Street Address
        /// </summary>
        public string StreetAddress { get; set; }
        /// <summary>
        /// Suburb
        /// </summary>
        public string Suburb { get; set; }
        /// <summary>
        /// Postcode
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Company Registration Number - Your government's company identification number
        /// </summary>
        public string CompanyRegistrationNumber { get; set; }

        /// <summary>
        /// Used to store extra information. Useful for extensions, add-ons, third-parties, etc...
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// The payment source to use. Leave blank to allow the payer to fill out this information using our hosted payment source capture page.
        /// </summary>
        public SourceSaveOptions Source { get; set; }
    }
}
