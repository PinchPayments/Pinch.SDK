using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Refunds
{
    /// <summary>
    /// Client for managing refund operations.
    /// </summary>
    public class RefundsClient : BaseClient
    {
        public RefundsClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }
        
        /// <summary>
        /// Get all refunds
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public Task<IEnumerable<Refund>> GetRefundsAll(DateTime? startDate = null, DateTime? endDate = null)
        {   
            return GetRefundsAll(null, 1, 50, startDate, endDate);
        }

        private async Task<IEnumerable<Refund>> GetRefundsAll(List<Refund> list, int currentPage, int pageSize, DateTime? startDate = null, DateTime? endDate = null)
        {
            list = list ?? new List<Refund>();

            var data = await GetRefunds(currentPage, pageSize, startDate, endDate);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetRefundsAll(list, currentPage + 1, pageSize, startDate, endDate);
            }

            return list;
        }
        
        /// <summary>
        /// Get refunds (paged)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<Paged<Refund>> GetRefunds(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var url = $"refunds?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            var response = await GetHttp<Paged<Refund>>(url);

            return response.Data;
        }
        
        /// <summary>
        /// Create a Refund
        /// </summary>
        /// <param name="options">Refund information.</param>
        /// <returns></returns>
        public async Task<ApiResponse<Refund>> Save(RefundSaveOptions options)
        {
            var response = await PostHttp<Refund>("refunds", options);
            return response.ToApiResponse();
        }

        /// <summary>
        /// Check a refund idempotency key
        /// </summary>
        /// <param name="options">Refund idempotency key.</param>
        /// <returns></returns>
        public async Task<IdempotencyKeyApiResponse<Refund>> CheckIdempotencyKey(RefundCheckIdempotencyKeyOptions options)
        {
            var response = await PostHttp<Refund>("refunds/idempotency-check", options);
            return response.ToIdempotencyKeyResponse();
        }
        
        /// <summary>
        /// Get a single refund with more details. 
        /// </summary>
        /// <param name="id">Refund Id in ref_XXXXXXXX format</param>
        /// <returns></returns>
        public async Task<Refund> Get(string id)
        {
            var response = await GetHttp<Refund>($"refunds/{id}");
            return response.Data;
        }
    }
}
