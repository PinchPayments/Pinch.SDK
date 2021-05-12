using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Events
{
    public class EventClient : BaseClient
    {
        public EventClient(PinchApiOptions options, Func<bool, Task<string>> getAccessToken, Func<HttpClient> httpClientFactory) 
            : base(options, getAccessToken, httpClientFactory)
        {
        }

        /// <summary>
        /// Get an Event by Id
        /// </summary>
        /// <param name="id">Event Id in evt_XXXXXXXXXXXXXX format.</param>
        /// <returns></returns>
        public async Task<EventDetailed> Get(string id)
        {
            var response = await GetHttp<EventDetailed>($"events/{id}");
            return response.Data;
        }

        /// <summary>
        /// Get all Events of a single type.
        /// </summary>
        /// <param name="eventType">If you wish to filter by a single Event type, eg `payment-created`. See https://docs.getpinch.com.au/reference#list-all-events for the list of all available event types. </param>
        /// <param name="startDate">Start date for date range filtering</param>
        /// <param name="endDate">End date for date range filtering</param>
        /// <returns></returns>
        public async Task<IEnumerable<Event>> GetByEventType(string eventType, DateTime? startDate = null, DateTime? endDate = null)
        {
            return await GetEventsAll(null, 1, 50, startDate, endDate, eventType);
        }

        /// <summary>
        /// All Events
        /// </summary>
        /// <param name="startDate">Start date for date range filtering</param>
        /// <param name="endDate">End date for date range filtering</param>
        /// <returns></returns>
        public async Task<IEnumerable<Event>> GetEventsAll(DateTime? startDate = null, DateTime? endDate = null)
        {
            return await GetEventsAll(null, 1, 50, startDate, endDate);
        }

        private async Task<IEnumerable<Event>> GetEventsAll(List<Event> list, int currentPage, int pageSize, DateTime? startDate = null, DateTime? endDate = null, string eventType = "")
        {
            list = list ?? new List<Event>();

            var data = await GetEvents(currentPage, pageSize, startDate, endDate, eventType);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetEventsAll(list, currentPage + 1, pageSize, startDate, endDate, eventType);
            }

            return list;
        }

        /// <summary>
        /// Get all Events paged.
        /// </summary>
        /// <param name="page">Default: 1</param>
        /// <param name="pageSize">Default: 50</param>
        /// <param name="startDate">Start date for date range filtering</param>
        /// <param name="endDate">End date for date range filtering</param>
        /// <param name="eventType">If you wish to filter by a single Event type, eg `payment-created`. See https://docs.getpinch.com.au/reference#list-all-events for the list of all available event types. </param>
        /// <returns></returns>
        public async Task<Paged<Event>> GetEvents(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null, string eventType = "")
        {
            var url = $"events?page={page}&pagesize={pageSize}";

            if (startDate.HasValue)
            {
                url += $"&startDate={startDate.Value:yyyy-MM-dd}";
            }

            if (endDate.HasValue)
            {
                url += $"&endDate={endDate.Value:yyyy-MM-dd}";
            }

            if (!string.IsNullOrWhiteSpace(eventType))
            {
                url += $"&eventType={eventType}";
            }

            var response = await GetHttp<Paged<Event>>(url);

            return response.Data;           
        }

    }
}
