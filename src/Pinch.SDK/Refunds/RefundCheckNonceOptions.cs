namespace Pinch.SDK.Refunds
{
    /// <summary>
    /// Options for checking a refund nonce in the Pinch Payments API.
    /// </summary>
    /// <remarks>
    /// This class is used to specify the nonce value when verifying a refund request.
    /// Nonces are used for idempotency to prevent duplicate refund processing.
    /// </remarks>
    public class RefundCheckNonceOptions
    {
        /// <summary>
        /// Gets or sets the nonce value associated with the refund request.
        /// </summary>
        /// <remarks>
        /// The nonce is a unique identifier used to check if a refund request has already been processed,
        /// enabling idempotent refund operations and preventing accidental duplicate refunds.
        /// </remarks>
        public string Nonce { get; set; }
    }
}