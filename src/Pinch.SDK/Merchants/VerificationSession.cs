using System;

namespace Pinch.SDK.Merchants
{
    /// <summary>
    /// Create Verification Session Response
    /// </summary>
    public class VerificationSession
    {
        /// <summary>
        /// The fully qualified URL to verify the contact
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Expiry time of the token in Utc
        /// </summary>
        public DateTime ExpiryUtc { get; set; }

        /// <summary>
        /// Token used to verify the user
        /// </summary>
        public Guid Token { get; set; }
    }
}