using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pinch.SDK.Helpers;

namespace Pinch.SDK.Events
{
    public interface IEventClient
    {
        Task<EventDetailed> Get(string id);
        Task<IEnumerable<Event>> GetEventsAll(DateTime? startDate = null, DateTime? endDate = null);
        Task<Paged<Event>> GetEvents(int page = 1, int pageSize = 50, DateTime? startDate = null, DateTime? endDate = null);
    }
}