using Newtonsoft.Json;
using Pinch.SDK.Converters;
using System.Collections.Generic;

namespace Pinch.SDK.Helpers
{
    public class IdempotencyKeyResponseDto
    {
        public bool IsIdempotencyKeyReplay { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> IdempotencyKey { get; set; }
    }

    public class IdempotencyKeyResponseDto<T> : IdempotencyKeyResponseDto
    {
        public T Data { get; set; }
    }
}