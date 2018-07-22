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
        /// The payment source to use. Leave blank to allow the payer to fill out this information using our hosted payment source capture page.
        /// </summary>
        public SourceSaveOptions Source { get; set; }
    }
}
