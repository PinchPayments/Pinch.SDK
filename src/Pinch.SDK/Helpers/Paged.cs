using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinch.SDK.Helpers
{
    public class Paged<T>
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalItems { get; set; }
        public IEnumerable<T> Data { get; set; }

        public Paged(IEnumerable<T> data)
        {
            Data = data;
        }
    }
}
