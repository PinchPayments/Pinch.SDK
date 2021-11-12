using System;
using System.Collections;
using System.Collections.Generic;

namespace Pinch.SDK.Transfers
{
    public class Transfer
    {
        public string Id { get; set; }
        public DateTime TransferDate { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Bsb { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public decimal TaxRate { get; set; }
    }
}
