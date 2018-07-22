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

        public async Task<EventDetailed> Get(string id)
        {
            var response = await GetHttp<EventDetailed>($"events/{id}");

            return response.Data;
        }

        public async Task<IEnumerable<Event>> GetEventsAll(DateTime? startDate = null, DateTime? endDate = null)
        {
            return await GetEventsAll(null, 1, 50, startDate, endDate);
        }

        private async Task<IEnumerable<Event>> GetEventsAll(List<Event> list, int currentPage, int pageSize, DateTime? startDate = null, DateTime? endDate = null)
        {
            list = list ?? new List<Event>();

            var data = await GetEvents(currentPage, pageSize, startDate, endDate);
            list.AddRange(data.Data);

            if (data.totalPages > currentPage)
            {
                await GetEventsAll(list, currentPage + 1, pageSize);
            }

            return list;
        }

        public async Task<Paged<Event>> GetEvents(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null)
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

            var response = await GetHttp<Paged<Event>>(url);

            return response.Data;           
        }

    }
}
