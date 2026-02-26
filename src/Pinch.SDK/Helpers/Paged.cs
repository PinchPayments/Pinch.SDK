using System.Collections.Generic;

namespace Pinch.SDK.Helpers
{
    /// <summary>
    /// Represents a paginated result set containing data of a specified type along with pagination metadata.
    /// </summary>
    /// <typeparam name="T">The type of items contained in the paginated result.</typeparam>
    public class Paged<T>
    {
        /// <summary>
        /// Gets or sets the current page number (typically 1-based).
        /// </summary>
        public int page { get; set; }
        
        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        public int pageSize { get; set; }
        
        /// <summary>
        /// Gets or sets the total number of pages available.
        /// </summary>
        public int totalPages { get; set; }
        
        /// <summary>
        /// Gets or sets the total number of items across all pages.
        /// </summary>
        public int totalItems { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of items for the current page.
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Paged{T}"/> class with the specified data.
        /// </summary>
        /// <param name="data">The collection of items for the current page.</param>
        public Paged(IEnumerable<T> data)
        {
            Data = data;
        }
    }
}
