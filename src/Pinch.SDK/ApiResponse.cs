using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pinch.SDK.Converters;
using Pinch.SDK.Helpers;

namespace Pinch.SDK
{
    public class NonceApiResponse<T> : ApiResponse<T>
    {
        public bool IsNonceReplay { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Nonce { get; set; }
    }

    public class ApiResponse
    {
        public bool Success => !Errors.Any();
        public List<ApiError> Errors { get; set; }

        public ApiResponse()
        {
            Errors = new List<ApiError>();
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }

    public class ApiResponse<T, TOptions> : ApiResponse<T>
    {
        public TOptions InlineErrors { get; set; }
    }

    public class ApiError
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}
