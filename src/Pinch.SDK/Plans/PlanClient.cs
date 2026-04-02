using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Plans
{
    /// <summary>
    /// Client for managing subscription plans in the Pinch API.
    /// Provides operations to retrieve, create, update, and delete plans, as well as calculate subscription payments.
    /// </summary>
    public class PlanClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanClient"/> class.
        /// </summary>
        /// <param name="options">API configuration options.</param>
        /// <param name="getAccessToken">Function to retrieve the access token for authentication.</param>
        /// <param name="httpClientFactory">Factory function to create HTTP client instances.</param>
        public PlanClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Retrieves all plans for the current merchant by recursively fetching all pages.
        /// </summary>
        /// <remarks>
        /// WARNING: This method retrieves all pages of plans in a single operation. Use sparingly as it may consume significant bandwidth 
        /// and processing time for merchants with large plan catalogs. Consider using <see cref="GetPlans"/> with pagination for better performance.
        /// </remarks>
        /// <param name="list">The current list of accumulated plans. If null, a new list is initialized.</param>
        /// <param name="currentPage">The current page number being retrieved. Defaults to 1.</param>
        /// <param name="pageSize">Number of plans to retrieve per API call. Defaults to 50.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the complete enumerable list of all plans, or error details if the operation fails.</returns>
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
        /// Retrieves a paginated list of all plans for the current merchant.
        /// </summary>
        /// <param name="page">The page number to retrieve. Defaults to 1.</param>
        /// <param name="pageSize">The number of plans per page. Defaults to 50.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing a paginated collection of plans and pagination metadata.</returns>
        public async Task<ApiResponse<Paged<Plan>>> GetPlans(int page = 1, int pageSize = 50)
        {
            var response = await GetHttp<Paged<Plan>>($"plans?page={page}&pagesize={pageSize}");            

            return response.ToApiResponse();
        }

        /// <summary>
        /// Retrieves detailed properties for a specific plan.
        /// </summary>
        /// <param name="id">The unique identifier of the plan to retrieve.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the plan details, or error information if the plan is not found.</returns>
        public async Task<ApiResponse<Plan>> Get(string id)
        {
            var response = await GetHttp<Plan>($"plans/{id}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Creates a new plan or updates an existing plan.
        /// </summary>
        /// <param name="options">Plan configuration options containing all fields to be created or updated.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the saved plan details with any server-generated values, or validation/error details on failure.</returns>
        /// <remarks>
        /// Uses POST method to handle inline validation errors. All fields in <paramref name="options"/> will be sent to the API.
        /// </remarks>
        public async Task<ApiResponse<Plan, PlanSaveOptions>> Save(PlanSaveOptions options)
        {
            // Must use PostHttp<T, TOptions> to handle inline errors response
            var response = await PostHttp<Plan, PlanSaveOptions>("plans", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Deletes a plan by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the plan to delete.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating success or containing error details if the deletion fails.</returns>
        public async Task<ApiResponse> Delete(string id)
        {
            var response = await DeleteHttp($"plans/{id}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Calculates scheduled payment amounts for a subscription plan based on specified criteria.
        /// </summary>
        /// <remarks>
        /// This method allows filtering calculated payments by start date, total amount, and pagination parameters.
        /// All optional parameters can be combined to narrow the results.
        /// </remarks>
        /// <param name="planId">The unique identifier of the plan for which to calculate payments.</param>
        /// <param name="startDate">Optional. The start date for the payment calculation period in ISO 8601 format.</param>
        /// <param name="totalAmount">Optional. The total subscription amount in minor currency units (e.g., cents).</param>
        /// <param name="skip">Optional. Number of records to skip for pagination.</param>
        /// <param name="limit">Optional. Maximum number of records to retrieve.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing a list of calculated subscription payments, or error details if the calculation fails.</returns>
        public async Task<ApiResponse<List<CalculatedSubscriptionPayment>>> CalculatedPayments(string planId, DateTime? startDate = null, long? totalAmount = null, int? skip = null, int? limit = null)
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
            if (skip.HasValue)
            {
                url += $"&skip={skip}";
            }
            if (limit.HasValue)
            {
                url += $"&limit={limit}";
            }

            var response = await GetHttp<List<CalculatedSubscriptionPayment>>(url);

            return response.ToApiResponse();
        }
    }
}
