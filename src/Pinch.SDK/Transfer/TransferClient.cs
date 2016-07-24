using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Transfer
{
    public class TransferClient
    {
        private readonly HttpClient _client;
        private readonly Func<Task<string>> _getAccessToken;

        public TransferClient(string baseUri, Func<Task<string>> getAccessToken)
        {
            _getAccessToken = getAccessToken;
            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<Transfer> Get(string id)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Get<Transfer>($"transfers/{id}");

            return response.Data;
        }

        public async Task<List<Transfer>> GetTransfers()
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Get<List<Transfer>>("transfers");

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
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var url = $"transfers/items/{id}?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            var response = await _client.Get<Paged<TransferLineItem>>(url);

            return response.Data;
        }

    }
}
