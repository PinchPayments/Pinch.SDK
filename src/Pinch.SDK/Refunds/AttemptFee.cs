namespace Pinch.SDK.Refunds
{
    public class AttemptFee
    {
        public long TransactionFee { get; set; }
        public long ApplicationFee { get; set; }
        public long TotalFee { get; set; }
        public string Currency { get; set; }
        public decimal TaxRate { get; set; }
        public long? ConvertedTransactionFee { get; set; }
        public long? ConvertedApplicationFee { get; set; }
        public long? ConvertedTotalFee { get; set; }
        public string ConvertedCurrency { get; set; }
        public decimal? ConversionRate { get; set; }
    }
}