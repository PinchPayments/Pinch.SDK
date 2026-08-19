namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Represents merchant identifier information used for authentication or identification purposes.
    /// </summary>
    /// <remarks>
    /// This data transfer object (DTO) encapsulates the merchant's unique identifier
    /// and the associated identity provider used for authentication or validation.
    /// </remarks>
    public class MerchantIdentifierDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the merchant.
        /// </summary>
        /// <remarks>
        /// This identifier is typically assigned by the system or the identity provider
        /// and is used to uniquely identify a merchant across the Pinch platform.
        /// </remarks>
        public string MerchantIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the identity provider associated with this merchant identifier.
        /// </summary>
        /// <remarks>
        /// The identity provider is the external service or system responsible for
        /// authenticating and managing the merchant's identity (e.g., OAuth provider, SSO system).
        /// </remarks>
        public string IdentityProvider { get; set; }
    }
}