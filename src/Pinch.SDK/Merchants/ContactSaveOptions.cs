namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Represents the options for saving or updating a merchant contact.
    /// </summary>
    public class ContactSaveOptions
    {
        /// <summary>
        /// Gets or sets the unique identifier for the contact.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this contact is the primary contact for the merchant.
        /// </summary>
        public bool IsPrimaryContact { get; set; }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the contact.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the contact.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the street address of the contact.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the suburb or city of the contact's address.
        /// </summary>
        public string Suburb { get; set; }

        /// <summary>
        /// Gets or sets the postcode of the contact's address.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the state or province of the contact's address.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country of the contact's address.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the contact.
        /// </summary>
        public string Dob { get; set; }

        /// <summary>
        /// Gets or sets the government identification number of the contact.
        /// </summary>
        public string GovernmentNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of contact (e.g., individual, business representative).
        /// </summary>
        public string ContactType { get; set; }

        /// <summary>
        /// Gets or sets the ownership percentage of the contact in the merchant entity.
        /// </summary>
        public decimal? Ownership { get; set; }

        /// <summary>
        /// Gets or sets the job title of the contact.
        /// </summary>
        public string JobTitle { get; set; }
    }
}
