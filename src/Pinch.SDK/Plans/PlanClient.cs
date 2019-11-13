using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;
using Pinch.SDK.Payers;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Plans
{
    public class PlanClient : BaseClient
    {
        public PlanClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Get all plans for the current Merchant. Warning, retrieves all pages; Please use sparingly.
        /// </summary>
        /// <param name="list">The current list of plans</param>
        /// <param name="currentPage">The current page</param>
        /// <param name="pageSize">Number of plans to retrieve with each call to the API</param>
        /// <returns></returns>
        public async Task<ApiResponse<IEnumerable<Plan>>> GetPlansAll(List<Plan> list = null, int currentPage = 1, int pageSize = 50)
        {
            list = list ?? new List<Plan>();

            var data = await GetPlans(currentPage, pageSize);

            if (!data.Success)
            {
                return new ApiResponse<IEnumerable<Plan>>()
                {
                    Errors = data.Errors
                };
            }

            list.AddRange(data.Data.Data);

            if (data.Data.totalPages > currentPage)
            {
                await GetPlansAll(list, currentPage + 1, pageSize);
            }

            return new ApiResponse<IEnumerable<Plan>>()
            {
                Data = list                
            };
        }

        /// <summary>
        /// Get all Plans for the current Merchant (Paged).
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<Paged<Plan>>> GetPlans(int page = 1, int pageSize = 50)
        {
            var response = await GetHttp<Paged<Plan>>($"plans?page={page}&pagesize={pageSize}");            

            return response.ToApiResponse();
        }

        /// <summary>
        /// Fetches detailed properties for a single Plan.
        /// </summary>
        /// <param name="id">Plan ID</param>
        /// <returns></returns>
        public async Task<ApiResponse<Plan>> Get(string id)
        {
            var response = await GetHttp<Plan>($"plans/{id}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Add or Update a Plan
        /// </summary>
        /// <param name="options">Plan information. All fields will be used.</param>
        /// <returns></returns>
        public async Task<ApiResponse<Plan, PlanSaveOptions>> Save(PlanSaveOptions options)
        {
            var response = await PostHttp<Plan, PlanSaveOptions>("plans", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Delete a plan
        /// </summary>
        /// <param name="id">The Plan ID to delete</param>
        /// <returns></returns>
        public async Task<ApiResponse> Delete(string id)
        {
            var response = await DeleteHttp($"plans/{id}");

            return response.ToApiResponse();
        }

        public async Task<ApiResponse<List<CalculatedSubscriptionPayment>>> CalculatedPayments(string planId, DateTime? startDate, long? totalAmount)
        {
            var url = $"plans/{planId}/calculated-payments?1=1";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value.ToString("o")}";
            }
            if (totalAmount.HasValue)
            {
                url += $"&totalAmount={totalAmount}";
            }

            var response = await GetHttp<List<CalculatedSubscriptionPayment>>(url);

            return response.ToApiResponse();
        }
    }
}
