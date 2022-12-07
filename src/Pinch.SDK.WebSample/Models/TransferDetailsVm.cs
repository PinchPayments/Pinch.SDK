using Pinch.SDK.Transfers;

namespace Pinch.SDK.WebSample.Models
{
    public class TransferDetailsVm
    {
        public TransferDetailed Transfer { get; set; }
        public IEnumerable<TransferLineItem> LineItems { get; set; } = new List<TransferLineItem>();
    }
}
