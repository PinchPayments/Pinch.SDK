using System.Collections.Generic;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;
using Pinch.SDK.Sources;

namespace Pinch.SDK.Payers
{
    public interface IPayerClient
    {
        /// <summary>
        /// Get all payers for the current Merchant. Warning, retrieves all pages; Please use sparingly.
        /// </summary>
        /// <param name="list">The current list of Payers</param>
        /// <param name="currentPage">The current page</param>
        /// <param name="pageSize">Number of payers to retrieve with each call to the API</param>
        /// <returns></returns>
        Task<ApiResponse<IEnumerable<Payer>>> GetPayersAll(List<Payer> list = null, int currentPage = 1, int pageSize = 50);

        /// <summary>
        /// Get all Payers for the current Merchant (Paged).
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse<Paged<Payer>>> GetPayers(int page = 1, int pageSize = 50);

        /// <summary>
        /// Fetches detailed properties for a single Payer.
        /// </summary>
        /// <param name="id">Payer ID</param>
        /// <param name="merchantId">Internal use only</param>
        /// <returns></returns>
        Task<ApiResponse<PayerDetailed>> Get(string id, string merchantId = null);

        /// <summary>
        /// Add or Update a Payer
        /// </summary>
        /// <param name="options">Payer information. All fields will be used.</param>
        /// <returns></returns>
        Task<ApiResponse<PayerDetailed>> Save(PayerSaveOptions options);

        /// <summary>
        /// Add a new Payment Source to a Payer
        /// </summary>
        /// <param name="payerId">Payer ID to attach source to</param>
        /// <param name="options">The source information. Only supply the parts you need.</param>
        /// <returns></returns>
        Task<ApiResponse<Source>> SaveSource(string payerId, SourceSaveOptions options);

        /// <summary>
        /// Delete a payer
        /// </summary>
        /// <param name="id">The Payer ID to delete</param>
        /// <returns></returns>
        Task<ApiResponse> Delete(string id);
    }
}