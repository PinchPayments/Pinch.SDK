using System;
using System.Collections.Generic;
using System.Text;

namespace Pinch.SDK.Webhooks
{
    public static class EventTypes
    {
        public const string BankResults = "bank-results";
        public const string ScheduledProcess = "scheduled-process";
        public const string Transfer = "transfer";
        public const string RealtimePayment = "realtime-payment";
        public const string PaymentCreated = "payment-created";
        public const string SubscriptionComplete = "subscription-complete";
        public const string PayerCreated = "payer-created";
        public const string PayerUpdated = "payer-updated";
        public const string RefundCreated = "refund-created";
        public const string RefundUpdated = "refund-updated";

        public const string ComplianceUpdated = "compliance-updated";
        public const string DisputeCreated = "dispute-created";
        public const string DisputeUpdated = "dispute-updated";
        public const string MerchantCreated = "merchant-created";
        public const string MerchantUpdated = "merchant-updated";

        public const string MerchantComplianceUpdated = "merchant-compliance-updated";
        public const string SubscriptionCreated = "subscription-created";
        public const string SubscriptionCancelled = "subscription-cancelled";
        public const string ReportOnlyPayment = "reportonly-payment";

    }
}
