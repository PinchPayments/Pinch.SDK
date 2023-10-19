using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;
using Pinch.SDK.Merchants;

namespace Pinch.SDK.Statements
{
    public class StatementsClient : BaseClient
    {
        public StatementsClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory) 
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Gets the Daily statements (paged)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public async Task<Paged<DailyStatement>> GetDailyStatements(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var url = $"statements/daily?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }
            
            var response = await GetHttp<Paged<DailyStatement>>(url);

            return response.Data;
        }

        /// <summary>
        /// Re-sends the daily statement email to the merchant
        /// </summary>
        /// <param name="dailyStatementId"></param>
        public async Task<ApiResponse> ResendDailyStatement(string dailyStatementId)
        {
            var url = $"statements/daily/{dailyStatementId}/resend-email";
            var response = await PostHttp<string>(url, null);
            return response.ToApiResponse();
        }

        /// <summary>
        /// Gets the daily statement PDF for the merchant
        /// </summary>
        /// <param name="dailyStatementId"></param>
        public async Task<ApiResponse<FileDto>> GetDailyStatementPdf(string dailyStatementId)
        {
            var response = await GetFile($"statements/daily/{dailyStatementId}");
            return response.ToApiResponse();
        }

        /// <summary>
        /// Gets the merchant invoices (paged)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public async Task<Paged<MerchantInvoice>> GetMonthlyInvoices(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
        {
            var url = $"statements/merchant-invoice?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }
            
            var response = await GetHttp<Paged<MerchantInvoice>>(url);

            return response.Data;
        }

        /// <summary>
        /// Re-sends the merchant invoice email to the merchant
        /// </summary>
        /// <param name="merchantInvoiceId"></param>
        public async Task<ApiResponse> ResendMerchantInvoice(string merchantInvoiceId)
        {
            var url = $"statements/merchant-invoice/{merchantInvoiceId}/resend-email";
            var response = await PostHttp<string>(url, null);
            return response.ToApiResponse();
        }

        /// <summary>
        /// Gets the merchant invoice PDF
        /// </summary>
        /// <param name="merchantInvoiceId"></param>
        public async Task<ApiResponse<FileDto>> GetMerchantInvoicePdf(string merchantInvoiceId)
        {
            var response = await GetFile($"statements/merchant-invoice/{merchantInvoiceId}");
            return response.ToApiResponse();
        }
    }
}

