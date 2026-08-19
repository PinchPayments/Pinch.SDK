namespace Pinch.SDK.Refunds
{
    /// <summary>
    /// Options for checking a refund using an nonce.
    /// </summary>
    /// <remarks>
    /// This class is used to specify a nonce when retrieving or verifying
    /// the status of a refund request. The nonce ensures that duplicate
    /// refund check requests are safely deduplicated by the server.
    /// </remarks>
    public class RefundCheckNonceOptions
    {
        /// <summary>
        /// Gets or sets the nonce for the refund check request.
        /// </summary>
        /// <remarks>
        /// The nonce is a unique identifier used to ensure idempotent behavior.
        /// If the same nonce is used for multiple requests, the server will
        /// return the same result without processing the request multiple times.
        /// </remarks>
        public string Nonce { get; set; }
    }
}
