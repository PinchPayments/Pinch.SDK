using System;

namespace Pinch.SDK.Transfers
{
    public class TransferLineItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Gross { get; set; }
        public int Fees { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Total { get; set; }
    }
}
