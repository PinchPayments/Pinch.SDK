using System.ComponentModel;

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
        /// The Payer's BSB (Bank State Branch number). Must be 6 digits. Everything except numbers will be stripped.
        /// </summary>
        public string BSB { get; set; }
        /// <summary>
        /// The Payer's Bank Account Number. Currently must be between 3 and 10 digits long (inclusive). Everything except numbers will be stripped.
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// The Payer's Bank Account Name. If left blank, it will be set to the Payer's name.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// This can only be used by trusted/internal clients. It allows you to select which merchant the payer will be added to.
        /// </summary>
        public string MerchantId { get; set; }
    }
}
