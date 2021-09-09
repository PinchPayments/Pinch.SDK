using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Transfers
{
    public class TransferClient : BaseClient
    {
        public TransferClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        public async Task<TransferDetailed> Get(string id)
        {
            var response = await GetHttp<TransferDetailed>($"transfers/{id}");

            return response.Data;
        }

        public async Task<List<Transfer>> GetTransfers(int page = 1, int pageSize = 50)
        {
            var response = await GetHttp<List<Transfer>>($"transfers?page={page}&pagesize={pageSize}");

            return response.Data;
        }

        public async Task<IEnumerable<TransferLineItem>> GetLineItemsAll(string id, List<TransferLineItem> list = null, int currentPage = 1, int pageSize = 50)
        {
            list = list ?? new List<TransferLineItem>();

            var data = await GetLineItems(id, currentPage, pageSize);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetLineItemsAll(id, list, currentPage + 1, pageSize);
            }

            return list;
        }

        public async Task<Paged<TransferLineItem>> GetLineItems(string id, int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var url = $"transfers/items/{id}?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            var response = await GetHttp<Paged<TransferLineItem>>(url);

            return response.Data;
        }

    }
}
