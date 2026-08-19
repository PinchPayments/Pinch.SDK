using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Payers
{
    /// <summary>
    /// Provides client operations for managing Payers in the Pinch SDK.
    /// This class handles all payer-related API interactions including retrieval, creation, updates,
    /// and deletion of payers, as well as management of payment sources attached to payers.
    /// </summary>
    /// <remarks>
    /// The PayerClient extends BaseClient and uses the provided PinchApiOptions and authentication
    /// delegate to facilitate secure API communication. All methods are asynchronous and return
    /// ApiResponse objects that include both data and error information.
    /// </remarks>
    public class PayerClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the PayerClient class.
        /// </summary>
        /// <param name="options">Configuration options for the Pinch API including base URLs and API keys.</param>
        /// <param name="getAccessToken">An asynchronous delegate function that retrieves the current access token.
        /// The boolean parameter indicates whether to force a token refresh.</param>
        /// <param name="httpClientFactory">A factory function that creates or returns an HttpClient instance for API calls.</param>
        public PayerClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Retrieves all payers for the current Merchant by automatically paginating through all available pages.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method will recursively fetch all payers across all pages until all data is retrieved.
        /// Use with caution as this operation may take considerable time and bandwidth for merchants with large numbers of payers.
        /// Consider using GetPayers() for paginated access if dealing with large datasets.
        /// </para>
        /// <para>
        /// The method combines results from multiple API calls into a single enumerable collection.
        /// </para>
        /// </remarks>
        /// <param name="list">Optional: The current list of Payers. If null, a new list will be initialized. Used internally for recursion.</param>
        /// <param name="currentPage">Optional: The current page number to retrieve. Defaults to 1. Used internally for pagination tracking.</param>
        /// <param name="pageSize">Optional: The number of payers to retrieve per API call. Defaults to 50. Can be adjusted for optimal performance.</param>
        /// <returns>An ApiResponse containing an enumerable collection of all Payer objects, or error information if the operation fails.</returns>
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
        /// Retrieves a paginated collection of Payers for the current Merchant.
        /// </summary>
        /// <remarks>
        /// This method returns results in a paginated format with metadata about total pages available.
        /// Use this method for large payer datasets to handle results in manageable chunks.
        /// </remarks>
        /// <param name="page">Optional: The page number to retrieve. Defaults to 1 (first page).</param>
        /// <param name="pageSize">Optional: The number of payers to include per page. Defaults to 50.</param>
        /// <returns>An ApiResponse containing a Paged collection of Payer objects with pagination metadata, or error information if the operation fails.</returns>
        public async Task<ApiResponse<Paged<Payer>>> GetPayers(int page = 1, int pageSize = 50)
        {
            var response = await GetHttp<Paged<Payer>>($"payers?page={page}&pagesize={pageSize}");            

            return response.ToApiResponse();
        }

        /// <summary>
        /// Retrieves detailed information for a single Payer by ID.
        /// </summary>
        /// <remarks>
        /// This method fetches comprehensive details about a specific payer including all associated properties.
        /// The optional merchantId parameter is provided for internal use and special access scenarios.
        /// </remarks>
        /// <param name="id">The unique identifier of the Payer to retrieve.</param>
        /// <param name="merchantId">Optional: Internal use only. Allows retrieval of payer details for a specific merchant context.</param>
        /// <returns>An ApiResponse containing detailed information about the requested Payer, or error information if not found or the operation fails.</returns>
        public async Task<ApiResponse<PayerDetailed>> Get(string id, string merchantId = null)
        {
            var response = await GetHttp<PayerDetailed>($"payers/{id}" + (!string.IsNullOrEmpty(merchantId) ? $"?merchantId={merchantId}": ""));

            return response.ToApiResponse();
        }

        /// <summary>
        /// Creates a new Payer or updates an existing Payer with the provided information.
        /// </summary>
        /// <remarks>
        /// This method performs an upsert operation. If a payer with the specified ID exists, it will be updated;
        /// otherwise, a new payer will be created. All fields provided in the options object will be used in the operation.
        /// </remarks>
        /// <param name="options">A PayerSaveOptions object containing the payer information. All supplied fields will be processed.</param>
        /// <returns>An ApiResponse containing the detailed information of the saved Payer, or error information if the operation fails.</returns>
        public async Task<ApiResponse<PayerDetailed>> Save(PayerSaveOptions options)
        {
            var response = await PostHttp<PayerDetailed>("payers", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Adds a new Payment Source (e.g., bank account, card) to an existing Payer.
        /// </summary>
        /// <remarks>
        /// This method allows attaching payment methods to a payer. Only the fields specified in the options
        /// need to be provided; optional fields can be omitted. The newly created source will be returned with
        /// all assigned properties including its unique identifier.
        /// </remarks>
        /// <param name="payerId">The unique identifier of the Payer to attach the source to.</param>
        /// <param name="options">A SourceSaveOptions object containing the source information. Only required fields need to be supplied.</param>
        /// <returns>An ApiResponse containing the created Source object with all details, or error information if the operation fails.</returns>
        public async Task<ApiResponse<Source>> SaveSource(string payerId, SourceSaveOptions options)
        {
            var response = await PostHttp<Source>($"payers/{payerId}/sources", options);

            return response.ToApiResponse();
        }

        /// <summary>
        /// Deletes a Payment Source that is attached to a Payer.
        /// </summary>
        /// <remarks>
        /// This operation removes the specified payment source from the payer's account. Once deleted,
        /// the source can no longer be used for transactions. Ensure the source ID is correct before
        /// deleting as this operation cannot be undone.
        /// </remarks>
        /// <param name="payerId">The unique identifier of the Payer that the source is attached to.</param>
        /// <param name="sourceId">The unique identifier of the Payment Source to delete.</param>
        /// <returns>An ApiResponse indicating success or failure of the deletion operation.</returns>
        public async Task<ApiResponse> DeleteSource(string payerId, string sourceId)
        {
            var response = await DeleteHttp($"payers/{payerId}/sources/{sourceId}");

            return response.ToApiResponse();
        }

        /// <summary>
        /// Deletes a Payer from the system.
        /// </summary>
        /// <remarks>
        /// This operation permanently removes the specified payer and all associated data from the system.
        /// This action cannot be reversed. Ensure the payer ID is correct before deleting.
        /// </remarks>
        /// <param name="id">The unique identifier of the Payer to delete.</param>
        /// <returns>An ApiResponse indicating success or failure of the deletion operation.</returns>
        public async Task<ApiResponse> Delete(string id)
        {
            var response = await DeleteHttp($"payers/{id}");

            return response.ToApiResponse();
        }
    }
}
