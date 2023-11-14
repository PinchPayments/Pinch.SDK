using Newtonsoft.Json;
using Pinch.SDK.Converters;
using System.Collections.Generic;

namespace Pinch.SDK.Helpers
{
    public class NonceResponseDto
    {
        public bool IsNonceReplay { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Nonce { get; set; }
    }

    public class NonceResponseDto<T> : NonceResponseDto
    {
        public T Data { get; set; }
    }
}