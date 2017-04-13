namespace Pinch.SDK.Payers
{
    /// <summary>
    /// A summarised list of properties for Payer, designed to be returned in lists.
    /// See <see cref="PayerClient.Get"/>
    /// </summary>
    public class Payer
    {
        /// <summary>
        /// The Payer ID
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
    }
}
