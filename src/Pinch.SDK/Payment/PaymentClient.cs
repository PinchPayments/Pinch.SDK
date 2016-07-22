using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Payment
{
    public class PaymentClient
    {
        private readonly HttpClient _client;
        private readonly Func<Task<string>> _getAccessToken;

        public PaymentClient(string baseUri, Func<Task<string>> getAccessToken)
        {
            _getAccessToken = getAccessToken;
            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<IEnumerable<Payment>> GetScheduledAll(List<Payment> list = null, int currentPage = 1, int pageSize = 50)
        {
            list = list ?? new List<Payment>();

            var data = await GetScheduled(currentPage, pageSize);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetScheduledAll(list, currentPage + 1, pageSize);
            }

            return list;
        }

        public async Task<Paged<Payment>> GetScheduled(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var url = $"payments/scheduled?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            var response = await _client.Get<Paged<Payment>>(url);

            return response.Data;
        }

        public async Task<IEnumerable<Payment>> GetProcessedAll(List<Payment> list = null, int currentPage = 1, int pageSize = 50)
        {
            list = list ?? new List<Payment>();

            var data = await GetProcessed(currentPage, pageSize);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetProcessedAll(list, currentPage + 1, pageSize);
            }

            return list;
        }

        public async Task<Paged<Payment>> GetProcessed(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var url = $"payments/processed?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            var response = await _client.Get<Paged<Payment>>(url);

            return response.Data;
        }

        public async Task<Payment> Get(string id)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Get<Payment>($"payments/{id}");

            return response.Data;
        }

        public async Task<ApiResponse<Payment>> Save(PaymentSaveOptions options)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Post<Payment>("payments", options);

            return new ApiResponse<Payment>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public async Task<ApiResponse> Delete(string id)
        {
            var token = await _getAccessToken();
            _client.DefaultRequestHeaders.Authorization = JwtAuthHeader.GetHeader(token);

            var response = await _client.Delete($"payments/{id}");

            return new ApiResponse()
            {
                Errors = response.Errors
            };
        }
    }
}
