using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pinch.SDK.Helpers
{
    public class HttpClientHelpers
    {
        public static HttpContent GetPostBody(Dictionary<string, string> parameters)
        {
            var formatted = parameters.Select(x => x.Key + "=" + x.Value);
            return new StringContent(string.Join("&", formatted), Encoding.UTF8, "application/x-www-form-urlencoded");
        }
    }

    public static class HttpClientExtensions
    {
        public static async Task<QuickResponse<T>> Get<T>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            return await QuickResponse<T>.FromMessage(response);
        }

        public static async Task<QuickResponse<T>> Post<T>(this HttpClient client, string url, Dictionary<string, string> parameters)
        {
            var response = await client.PostAsync(url, HttpClientHelpers.GetPostBody(parameters));
            return await QuickResponse<T>.FromMessage(response);
        }
    }

    public class QuickResponse<T>
    {
        public HttpResponseMessage Message { get; set; }

        public T Data { get; set; }
        public string ResponseBody { get; set; }

        public static async Task<QuickResponse<T>> FromMessage(HttpResponseMessage message)
        {
            var response = new QuickResponse<T>();
            response.Message = message;
            response.ResponseBody = await message.Content.ReadAsStringAsync();
            response.Data = JsonConvert.DeserializeObject<T>(response.ResponseBody);
            return response;
        }
    }
}
