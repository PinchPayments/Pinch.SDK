namespace Pinch.SDK.Webhooks
{
    /// <summary>
    /// Provides constant string values for webhook format options.
    /// </summary>
    /// <remarks>
    /// This static class defines the supported formatting conventions for webhook payload property names.
    /// These constants are used to configure how webhook data is serialized and delivered.
    /// </remarks>
    public static class WebhookFormats
    {
        /// <summary>
        /// Represents the PascalCase format convention for webhook property names.
        /// </summary>
        /// <remarks>
        /// When applied, property names in webhook payloads use PascalCase convention
        /// (e.g., "PropertyName", "TransactionId").
        /// </remarks>
        public const string PascalCase = "pascal-case";

        /// <summary>
        /// Represents the camelCase format convention for webhook property names.
        /// </summary>
        /// <remarks>
        /// When applied, property names in webhook payloads use camelCase convention
        /// (e.g., "propertyName", "transactionId").
        /// </remarks>
        public const string CamelCase = "camel-case";
    }
}
