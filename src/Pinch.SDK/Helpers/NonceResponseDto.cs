using Newtonsoft.Json;
using Pinch.SDK.Converters;
using System;
using System.Collections.Generic;

namespace Pinch.SDK.Helpers
{
    /// <summary>
    /// Represents the response containing nonce information from the Pinch API.
    /// 
    /// This class is used to deserialize API responses that include nonce-related metadata,
    /// allowing clients to determine whether a request was processed as new or replayed based on
    /// an nonce.
    /// </summary>
    [Obsolete("Use IdempotencyKeyResponseDto instead.")]
    public class NonceResponseDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether the current request is a replay of a previously
        /// processed idempotent request.
        /// 
        /// When true, the response data is from a previous request with the same nonce.
        /// When false, the request was processed as a new request.
        /// </summary>
        public bool IsNonceReplay { get; set; }

        /// <summary>
        /// Gets or sets the nonce(s) returned by the server.
        /// 
        /// The API may return either a single nonce as a string or multiple keys as an array.
        /// The <see cref="SingleOrArrayConverter{T}"/> automatically converts both formats into a list
        /// for consistent handling by the client.
        /// </summary>
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Nonce { get; set; }
    }

    /// <summary>
    /// Represents a typed response wrapper that includes idempotency key information along with response data.
    /// 
    /// This generic class extends <see cref="IdempotencyKeyResponseDto"/> to provide a complete response
    /// containing both idempotency metadata and the deserialized response data of type T.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the response payload.</typeparam>
    [Obsolete("Use IdempotencyKeyResponseDto<T> instead.")]
    public class NonceResponseDto<T> : NonceResponseDto
    {
        /// <summary>
        /// Gets or sets the typed response data returned by the API.
        /// 
        /// This contains the actual response payload from the API request, with the type specified
        /// by the generic type parameter T.
        /// </summary>
        public T Data { get; set; }
    }
}
