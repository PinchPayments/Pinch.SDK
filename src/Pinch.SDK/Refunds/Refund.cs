using Pinch.SDK.Payments;

namespace Pinch.SDK.Refunds
{
    public class Refund
    {
        public string Id { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public long RefundFeeCharged { get; set; }
        public string RequestedDate { get; set; }
        public string CompletedDate { get; set; }
        public string ReasonForRefund { get; set; }
        public string Notes { get; set; }
        public long? ConvertedAmount { get; set; }
        public decimal? ConversionRate { get; set; }
        public string ConvertedCurrency { get; set; }
        public bool IsGross { get; set; }
        public string Status { get; set; }
        public string TransferId { get; set; }
        public AttemptFee RefundedFees { get; set; }
        public string Nonce { get; set; }
        public string PaymentId { get; set; }
    }
}