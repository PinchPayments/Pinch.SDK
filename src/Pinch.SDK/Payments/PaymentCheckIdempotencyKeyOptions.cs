namespace Pinch.SDK.Payments
{
    /// <summary>
    /// Options for checking the idempotency key of a payment request.
    /// </summary>
    /// <remarks>
    /// Idempotency keys are used to ensure that duplicate payment requests are safely handled
    /// and produce the same result, preventing accidental duplicate payments.
    /// </remarks>
    public class PaymentCheckIdempotencyKeyOptions
    {
        /// <summary>
        /// Gets or sets the idempotency key used to identify a unique payment request.
        /// </summary>
        /// <value>
        /// A unique identifier string that ensures the same payment request can be safely retried
        /// without processing duplicate payments.
        /// </value>
        public string IdempotencyKey { get; set; }
    }
}