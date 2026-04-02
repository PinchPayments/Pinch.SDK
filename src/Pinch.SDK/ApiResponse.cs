using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinch.SDK.Converters;

namespace Pinch.SDK
{
    /// <summary>
    /// Represents an API response that includes idempotency key information.
    /// </summary>
    /// <typeparam name="T">The type of data returned in the response.</typeparam>
    /// <remarks>
    /// This class extends ApiResponse&lt;T&gt; to provide additional idempotency tracking,
    /// allowing clients to detect and handle replayed requests based on idempotency keys.
    /// </remarks>
    public class IdempotencyKeyApiResponse<T> : ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this response represents a replay of a previous idempotent request.
        /// </summary>
        public bool IsIdempotencyKeyReplay { get; set; }

        /// <summary>
        /// Gets or sets the idempotency key(s) associated with this request.
        /// </summary>
        /// <remarks>
        /// Can represent either a single string or an array of strings, which are converted
        /// using the SingleOrArrayConverter to normalize the input into a list.
        /// </remarks>
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> IdempotencyKey { get; set; }
    }

    /// <summary>
    /// Represents the base API response object containing common response properties.
    /// </summary>
    /// <remarks>
    /// This is the base class for all API responses and provides error handling capabilities.
    /// </remarks>
    public class ApiResponse
    {
        /// <summary>
        /// Gets a value indicating whether the API request was successful (no errors present).
        /// </summary>
        /// <value>True if the Errors collection is empty; otherwise, false.</value>
        public bool Success => !Errors.Any();

        /// <summary>
        /// Gets or sets the list of errors returned by the API.
        /// </summary>
        /// <remarks>
        /// An empty list indicates a successful response.
        /// </remarks>
        public List<ApiError> Errors { get; set; }

        /// <summary>
        /// Initializes a new instance of the ApiResponse class.
        /// </summary>
        public ApiResponse()
        {
            Errors = new List<ApiError>();
        }
    }

    /// <summary>
    /// Represents a generic API response containing typed data.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the response.</typeparam>
    public class ApiResponse<T> : ApiResponse
    {
        /// <summary>
        /// Gets or sets the data returned by the API.
        /// </summary>
        public T Data { get; set; }
    }

    /// <summary>
    /// Represents a generic API response with both typed data and inline error options.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the response.</typeparam>
    /// <typeparam name="TOptions">The type of inline error options provided with the response.</typeparam>
    public class ApiResponse<T, TOptions> : ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets inline error information that provides validation or business logic error details.
        /// </summary>
        /// <remarks>
        /// This allows the API to return structured error information alongside the success/error status.
        /// </remarks>
        public TOptions InlineErrors { get; set; }
    }

    /// <summary>
    /// Represents an error returned by the API.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// Gets or sets a machine-readable error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets a human-readable error message describing the error.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the name of the property that caused the error, if applicable.
        /// </summary>
        /// <remarks>
        /// This is typically used for validation errors to indicate which field failed validation.
        /// </remarks>
        public string PropertyName { get; set; }
    }
}
