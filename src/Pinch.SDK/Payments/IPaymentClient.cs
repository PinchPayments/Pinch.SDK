using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Payments
{
    public interface IPaymentClient
    {
        /// <summary>
        /// Get all scheduled payments
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<IEnumerable<PaymentExpanded>> GetScheduledAll(DateTime? startDate = null, DateTime? endDate = null);

        /// <summary>
        /// Get scheduled payments (paged)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<Paged<PaymentExpanded>> GetScheduled(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null);

        /// <summary>
        /// Get all processed payments
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<IEnumerable<PaymentExpanded>> GetProcessedAll(DateTime? startDate = null, DateTime? endDate = null);

        /// <summary>
        /// Get processed payments (paged)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<Paged<PaymentExpanded>> GetProcessed(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null);

        /// <summary>
        /// Get a single payment with more details. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PaymentDetailed> Get(string id);

        /// <summary>
        /// Get all payments for the given payer.
        /// </summary>
        /// <param name="payerId"></param>
        /// <returns></returns>
        Task<IEnumerable<PaymentExpanded>> GetForPayer(string payerId);

        /// <summary>
        /// Create or update a scheduled payment. Updates not supported after the payment has been processed.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ApiResponse<PaymentDetailed>> Save(PaymentSaveOptions options);

        /// <summary>
        /// Execute a payment in realtime. Only supports realtime sources (credit cards).
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ApiResponse<PaymentDetailed>> ExecuteRealtime(RealtimePaymentSaveOptions options);

        /// <summary>
        /// Delete a payment. Only scheduled payments that have not been processed can be deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse> Delete(string id);
    }
}