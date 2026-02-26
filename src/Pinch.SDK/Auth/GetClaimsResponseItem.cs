namespace Pinch.SDK.Auth
{
    /// <summary>
    /// Represents a claim item in the get claims response.
    /// </summary>
    public class GetClaimsResponseItem
    {
        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the claim.
        /// </summary>
        public string Value { get; set; }
    }
}
