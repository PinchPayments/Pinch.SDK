namespace Pinch.SDK.Refunds
{
    /// <summary>
    /// Options for checking a refund using an idempotency key.
    /// </summary>
    /// <remarks>
    /// This class is used to specify an idempotency key when retrieving or verifying
    /// the status of a refund request. The idempotency key ensures that duplicate
    /// refund check requests are safely deduplicated by the server.
    /// </remarks>
    public class RefundCheckIdempotencyKeyOptions
    {
        /// <summary>
        /// Gets or sets the idempotency key for the refund check request.
        /// </summary>
        /// <remarks>
        /// The idempotency key is a unique identifier used to ensure idempotent behavior.
        /// If the same idempotency key is used for multiple requests, the server will
        /// return the same result without processing the request multiple times.
        /// </remarks>
        public string IdempotencyKey { get; set; }
    }
}