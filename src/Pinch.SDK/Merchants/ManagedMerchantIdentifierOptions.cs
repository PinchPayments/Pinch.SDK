namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Object that defines a Merchant Identifier and Provider combination
    /// </summary>
    public class ManagedMerchantIdentifierOptions
    {
        /// <summary>
        /// The external identifier of the merchant
        /// </summary>
        public string MerchantIdentifier { get; set; }

        /// <summary>
        /// The external provider where this identifier is from
        /// </summary>
        public string IdentityProvider { get; set; }
    }
}