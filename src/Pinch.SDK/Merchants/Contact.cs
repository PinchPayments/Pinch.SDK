namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Represents a contact associated with a merchant account.
    /// </summary>
    /// <remarks>
    /// This class contains contact information including personal details, address information, 
    /// and metadata about the contact's relationship with the merchant.
    /// </remarks>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the unique identifier for the contact.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is the primary contact for the merchant.
        /// </summary>
        public bool IsPrimaryContact { get; set; }

        /// <summary>
        /// Gets or sets the contact's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the contact's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the contact's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the contact's phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the street address for the contact.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the suburb or locality for the contact's address.
        /// </summary>
        public string Suburb { get; set; }

        /// <summary>
        /// Gets or sets the postcode for the contact's address.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the state or province for the contact's address.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country for the contact's address.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the contact's date of birth.
        /// </summary>
        public string Dob { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a government-issued number (such as ABN or ACN) 
        /// has been supplied for this contact.
        /// </summary>
        public bool GovernmentNumberSupplied { get; set; }

        /// <summary>
        /// Gets or sets the type of contact (e.g., Director, Shareholder, Partner).
        /// </summary>
        public string ContactType { get; set; }

        /// <summary>
        /// Gets or sets the ownership percentage for this contact in the merchant entity.
        /// </summary>
        /// <remarks>
        /// This value may be null if ownership information is not applicable or available.
        /// </remarks>
        public decimal? Ownership { get; set; }

        /// <summary>
        /// Gets or sets the job title or position of the contact within the merchant organization.
        /// </summary>
        public string JobTitle { get; set; }
    }
}
