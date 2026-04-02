using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Transfers
{
    /// <summary>
    /// Client for retrieving transfers and transfer line items.
    /// </summary>
    public class TransferClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferClient"/> class.
        /// </summary>
        /// <param name="options">The API configuration options.</param>
        /// <param name="getAccessToken">Delegate used to retrieve access tokens.</param>
        /// <param name="httpClientFactory">Factory used to create <see cref="HttpClient"/> instances.</param>
        public TransferClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory)
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Gets a transfer by identifier.
        /// </summary>
        /// <param name="id">The transfer identifier.</param>
        /// <returns>The transfer details.</returns>
        public async Task<TransferDetailed> Get(string id)
        {
            var response = await GetHttp<TransferDetailed>($"transfers/{id}");

            return response.Data;
        }

        /// <summary>
        /// Gets a page of transfers.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A page of transfers.</returns>
        public async Task<Paged<Transfer>> GetTransfers(int page = 1, int pageSize = 50)
        {
            var response = await GetHttp<Paged<Transfer>>($"transfers?page={page}&pagesize={pageSize}");

            return response.Data;
        }

        /// <summary>
        /// Gets all transfer line items across pages.
        /// </summary>
        /// <param name="id">The transfer identifier.</param>
        /// <param name="list">Optional accumulator list.</param>
        /// <param name="currentPage">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>All line items for the transfer.</returns>
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

        /// <summary>
        /// Gets a page of transfer line items.
        /// </summary>
        /// <param name="id">The transfer identifier.</param>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="startDate">Optional start date filter.</param>
        /// <param name="endDate">Optional end date filter.</param>
        /// <returns>A page of transfer line items.</returns>
        public async Task<Paged<TransferLineItem>> GetLineItems(string id, int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var url = $"transfers/items/{id}?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            var response = await GetHttp<Paged<TransferLineItem>>(url);

            return response.Data;
        }

    }
}
