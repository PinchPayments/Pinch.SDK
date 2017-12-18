using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;
using Pinch.SDK.Payments;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Payers
{
    public class PayerClient : BaseClient
    {
        public PayerClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken)
            : base(options, getAccessToken)
        {
        }

        /// <summary>
        /// Get all payers for the current Merchant. Warning, retrieves all pages; Please use sparingly.
        /// </summary>
        /// <param name="list">The current list of Payers</param>
        /// <param name="currentPage">The current page</param>
        /// <param name="pageSize">Number of payers to retrieve with each call to the API</param>
        /// <returns></returns>
        public async Task<ApiResponse<IEnumerable<Payer>>> GetPayersAll(List<Payer> list = null, int currentPage = 1, int pageSize = 50)
        {
            list = list ?? new List<Payer>();

            var data = await GetPayers(currentPage, pageSize);

            if (!data.Success)
            {
                return new ApiResponse<IEnumerable<Payer>>()
                {
                    Errors = data.Errors
                };
            }

            list.AddRange(data.Data.Data);

            if (data.Data.totalPages > currentPage)
            {
                await GetPayersAll(list, currentPage + 1, pageSize);
            }

            return new ApiResponse<IEnumerable<Payer>>()
            {
                Data = list                
            };
        }

        /// <summary>
        /// Get all Payers for the current Merchant (Paged).
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<Paged<Payer>>> GetPayers(int page = 1, int pageSize = 50)
        {
            var response = await GetHttp<Paged<Payer>>($"payers?page={page}&pagesize={pageSize}");            

            return response.ToApiResponse();
        }

        /// <summary>
        /// Fetches detailed properties for a single Payer.
        /// </summary>
        /// <param name="id">Payer ID</param>
        /// <param name="merchantId">Internal use only</param>
        /// <returns></returns>
        public async Task<ApiResponse<PayerDetailed>> Get(string id, string merchantId = null)
        {
            var response = await GetHttp<PayerDetailed>($"payers/{id}" + (!string.IsNullOrEmpty(merchantId) ? $"?merchantId={merchantId}": ""));

            return response.ToApiResponse();
        }

        /// <summary>
        /// Add or Update a Payer
        /// </summary>
        /// <param name="options">Payer information. All fields will be used.</param>
        /// <returns></returns>
        public async Task<ApiResponse<PayerDetailed>> Save(PayerSaveOptions options)
        {
            var response = await PostHttp<PayerDetailed>("payers", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Add a new Payment Source to a Payer
        /// </summary>
        /// <param name="payerId">Payer ID to attach source to</param>
        /// <param name="options">The source information. Only supply the parts you need.</param>
        /// <returns></returns>
        public async Task<ApiResponse<Source>> SaveSource(string payerId, SourceSaveOptions options)
        {
            var response = await PostHttp<Source>($"payers/{payerId}/sources", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Delete a payer
        /// </summary>
        /// <param name="id">The Payer ID to delete</param>
        /// <returns></returns>
        public async Task<ApiResponse> Delete(string id)
        {
            var response = await DeleteHttp($"payers/{id}");

            return response.ToApiResponse();
        }
    }
}
