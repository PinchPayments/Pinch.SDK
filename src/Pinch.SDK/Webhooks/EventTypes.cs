namespace Pinch.SDK.Webhooks
{
    /// <summary>
    /// Defines the event type constants used for webhook notifications in the Pinch SDK.
    /// </summary>
    /// <remarks>
    /// This class contains static string constants that represent different webhook event types
    /// that can be received from the Pinch API. These event types are used to identify and
    /// route incoming webhook notifications to appropriate handlers.
    /// </remarks>
    public static class EventTypes
    {
        /// <summary>
        /// Event type for bank results.
        /// </summary>
        public const string BankResults = "bank-results";

        /// <summary>
        /// Event type for scheduled process events.
        /// </summary>
        public const string ScheduledProcess = "scheduled-process";

        /// <summary>
        /// Event type for transfer events.
        /// </summary>
        public const string Transfer = "transfer";

        /// <summary>
        /// Event type for real-time payment events.
        /// </summary>
        public const string RealtimePayment = "realtime-payment";

        /// <summary>
        /// Event type for payment creation events.
        /// </summary>
        public const string PaymentCreated = "payment-created";

        /// <summary>
        /// Event type for subscription completion events.
        /// </summary>
        public const string SubscriptionComplete = "subscription-complete";

        /// <summary>
        /// Event type for payer creation events.
        /// </summary>
        public const string PayerCreated = "payer-created";

        /// <summary>
        /// Event type for payer update events.
        /// </summary>
        public const string PayerUpdated = "payer-updated";

        /// <summary>
        /// Event type for refund creation events.
        /// </summary>
        public const string RefundCreated = "refund-created";

        /// <summary>
        /// Event type for refund update events.
        /// </summary>
        public const string RefundUpdated = "refund-updated";

        /// <summary>
        /// Event type for compliance update events.
        /// </summary>
        public const string ComplianceUpdated = "compliance-updated";

        /// <summary>
        /// Event type for dispute creation events.
        /// </summary>
        public const string DisputeCreated = "dispute-created";

        /// <summary>
        /// Event type for dispute update events.
        /// </summary>
        public const string DisputeUpdated = "dispute-updated";

        /// <summary>
        /// Event type for merchant creation events.
        /// </summary>
        public const string MerchantCreated = "merchant-created";

        /// <summary>
        /// Event type for merchant update events.
        /// </summary>
        public const string MerchantUpdated = "merchant-updated";

        /// <summary>
        /// Event type for merchant compliance update events.
        /// </summary>
        public const string MerchantComplianceUpdated = "merchant-compliance-updated";

        /// <summary>
        /// Event type for subscription creation events.
        /// </summary>
        public const string SubscriptionCreated = "subscription-created";

        /// <summary>
        /// Event type for subscription cancellation events.
        /// </summary>
        public const string SubscriptionCancelled = "subscription-cancelled";

        /// <summary>
        /// Event type for report-only payment events.
        /// </summary>
        public const string ReportOnlyPayment = "reportonly-payment";
    }
}
