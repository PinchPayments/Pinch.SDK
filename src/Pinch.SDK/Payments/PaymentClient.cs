using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Payments
{
    public class PaymentClient : BaseClient
    {
        public PaymentClient(string baseUri, Func<bool, Task<string>> getAccessToken)
            : base(baseUri, getAccessToken)
        {
        }

        public async Task<IEnumerable<PaymentExpanded>> GetScheduledAll(DateTime? startDate = null, DateTime? endDate = null)
        {
            return await GetScheduledAll(null, 1, 50, startDate, endDate);
        }

        private async Task<IEnumerable<PaymentExpanded>> GetScheduledAll(List<PaymentExpanded> list, int currentPage, int pageSize, DateTime? startDate = null, DateTime? endDate = null)
        {
            list = list ?? new List<PaymentExpanded>();

            var data = await GetScheduled(currentPage, pageSize, startDate, endDate);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetScheduledAll(list, currentPage + 1, pageSize);
            }

            return list;
        }

        public async Task<Paged<PaymentExpanded>> GetScheduled(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var url = $"payments/scheduled?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            var response = await GetHttp<Paged<PaymentExpanded>>(url);

            return response.Data;
        }


        public async Task<IEnumerable<PaymentExpanded>> GetProcessedAll(DateTime? startDate = null, DateTime? endDate = null)
        {
            return await GetProcessedAll(null, 1, 50, startDate, endDate);
        }

        private async Task<IEnumerable<PaymentExpanded>> GetProcessedAll(List<PaymentExpanded> list, int currentPage, int pageSize, DateTime? startDate = null, DateTime? endDate = null)
        {
            list = list ?? new List<PaymentExpanded>();

            var data = await GetProcessed(currentPage, pageSize, startDate, endDate);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetProcessedAll(list, currentPage + 1, pageSize);
            }

            return list;
        }

        public async Task<Paged<PaymentExpanded>> GetProcessed(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var url = $"payments/processed?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            var response = await GetHttp<Paged<PaymentExpanded>>(url);

            return response.Data;
        }

        public async Task<PaymentDetailed> Get(string id)
        {
            var response = await GetHttp<PaymentDetailed>($"payments/{id}");

            return response.Data;
        }
        
        public async Task<IEnumerable<Payment>> GetForPayer(string payerId)
        {
            var response = await GetHttp<IEnumerable<Payment>>($"payments/payer/{payerId}");

            return response.Data;
        }

        public async Task<ApiResponse<PaymentDetailed>> Save(PaymentSaveOptions options)
        {
            var response = await PostHttp<PaymentDetailed>("payments", options);

            return new ApiResponse<PaymentDetailed>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public async Task<ApiResponse> Delete(string id)
        {
            var response = await DeleteHttp($"payments/{id}");

            return new ApiResponse()
            {
                Errors = response.Errors
            };
        }
    }
}
