namespace Pinch.SDK.Refunds
{
    public class RefundSaveOptions
    {
        /// <summary>
        /// Required. Payment Id to execute the refund against. In pmt_XXXXXXXXXXXXXX format.
        /// </summary>
        public string PaymentId { get; set; }
        /// <summary>
        /// The refund amount in cents. eg. $10.00 = 1000
        /// </summary>
        public long? Amount { get; set; }
        /// <summary>
        /// Required. Reason for the refund.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Optional. Pinch will echo back the nonce value in the response, this is for replay protection.
        /// If the same Nonce is detected the in progress refund object will be returned.
        /// </summary>
        public string Nonce { get; set; }
    }
}