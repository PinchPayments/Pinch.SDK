namespace Pinch.SDK.Payments
{
    /// <summary>
    /// Options for checking the nonce of a payment request.
    /// </summary>
    /// <remarks>
    /// nonces are used to ensure that duplicate payment requests are safely handled
    /// and produce the same result, preventing accidental duplicate payments.
    /// </remarks>
    public class PaymentCheckNonceOptions
    {
        /// <summary>
        /// Gets or sets the nonce used to identify a unique payment request.
        /// </summary>
        /// <value>
        /// A unique identifier string that ensures the same payment request can be safely retried
        /// without processing duplicate payments.
        /// </value>
        public string Nonce { get; set; }
    }
}
