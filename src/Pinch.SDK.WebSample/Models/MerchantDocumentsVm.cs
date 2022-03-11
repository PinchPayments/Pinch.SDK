using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pinch.SDK.Merchants;

namespace Pinch.SDK.WebSample.Models
{
    public class MerchantDocumentsVm
    {
        public Merchant Merchant { get; set; }
        public List<Document> Documents { get; set; } = new List<Document>();

        public string DocumentType { get; set; }
        public IFormFile File { get; set; }
        public string ContactId { get; set; }
    }
}
