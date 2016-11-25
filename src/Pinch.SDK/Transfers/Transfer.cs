using System;

namespace Pinch.SDK.Transfers
{
    public class Transfer
    {
        public string Id { get; set; }
        public DateTime TransferDate { get; set; }
        public int Amount { get; set; }
        public string AccountNumber { get; set; }
        public string Bsb { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
    }
}
