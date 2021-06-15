using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Payments
{
    /// <summary>
    /// Payments API
    /// </summary>
    public class PaymentClient : BaseClient
    {
        public PaymentClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Get all scheduled payments
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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
                await GetScheduledAll(list, currentPage + 1, pageSize, startDate, endDate);
            }

            return list;
        }

        /// <summary>
        /// Get scheduled payments (paged)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all processed payments
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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
                await GetProcessedAll(list, currentPage + 1, pageSize, startDate, endDate);
            }

            return list;
        }

        /// <summary>
        /// Get processed payments (paged)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all payments for subscription
        /// </summary>
        /// <param name="subscriptionId">Subscription ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<PaymentExpanded>> GetForSubscriptionAll(string subscriptionId)
        {
            return await GetForSubscriptionAll(subscriptionId, null, 1, 50);
        }

        private async Task<IEnumerable<PaymentExpanded>> GetForSubscriptionAll(string subscriptionId, List<PaymentExpanded> list, int currentPage, int pageSize)
        {
            list = list ?? new List<PaymentExpanded>();

            var data = await GetForSubscription(subscriptionId, currentPage, pageSize);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetForSubscriptionAll(subscriptionId, list, currentPage + 1, pageSize);
            }

            return list;
        }

        /// <summary>
        /// Get payments for subscription (paged)
        /// </summary>
        /// <param name="subscriptionId">Subscription ID</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Paged<PaymentExpanded>> GetForSubscription(string subscriptionId, int page = 1, int pageSize = 50)
        {
            var url = $"payments/subscription/{subscriptionId}?page={page}&pagesize={pageSize}";

            var response = await GetHttp<Paged<PaymentExpanded>>(url);

            return response.Data;
        }

        /// <summary>
        /// Get a single payment with more details. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PaymentDetailed> Get(string id)
        {
            var response = await GetHttp<PaymentDetailed>($"payments/{id}");

            return response.Data;
        }
        
        /// <summary>
        /// Get all payments for the given payer.
        /// </summary>
        /// <param name="payerId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PaymentExpanded>> GetForPayer(string payerId)
        {
            var response = await GetHttp<IEnumerable<PaymentExpanded>>($"payments/payer/{payerId}");

            return response.Data;
        }

        /// <summary>
        /// Create or update a scheduled payment. Updates not supported after the payment has been processed.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<ApiResponse<PaymentDetailed>> Save(PaymentSaveOptions options)
        {
            var response = await PostHttp<PaymentDetailed>("payments", options);

            return new ApiResponse<PaymentDetailed>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        /// <summary>
        /// Execute a payment in realtime. Only supports realtime sources (credit cards).
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<ApiResponse<PaymentDetailed>> ExecuteRealtime(RealtimePaymentSaveOptions options)
        {
            var response = await PostHttp<PaymentDetailed>("payments/realtime", options);

            return new ApiResponse<PaymentDetailed>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        /// <summary>
        /// Delete a payment. Only scheduled payments that have not been processed can be deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> Delete(string id)
        {
            var response = await DeleteHttp($"payments/{id}");

            return new ApiResponse()
            {
                Errors = response.Errors
            };
        }

        /// <summary>
        /// Check a payment nonce
        /// </summary>
        /// <param name="options">Payment nonce.</param>
        /// <returns></returns>
        public async Task<ApiResponse<NonceResponse<PaymentDetailed>>> CheckNonce(PaymentCheckNonceOptions options)
        {
            var response = await PostHttp<NonceResponse<PaymentDetailed>>("payments/nonce", options);
            return response.ToApiResponse();
        }
    }
}
