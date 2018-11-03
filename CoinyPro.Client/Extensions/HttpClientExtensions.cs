using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoinyPro.Client.Extensions
{
    public static class HttpClientExtensions
    {

        public static async Task<TResponse> PostItemAsync<TResponse>(this HttpClient client, string uri, object request)
        {
            var result = await client.PostAsJsonAsync(uri, request);
            return await ConvertToModelAsync<TResponse>(result);
        }
        public static async Task<TResponse> GetItemAsync<TResponse>(this HttpClient client, string uri)
        {
            var result = await client.GetAsync(uri);
            return await ConvertToModelAsync<TResponse>(result);
        }

        public static async Task<HttpResponseMessage> DeleteItemAsync(this HttpClient client, string uri, string data = null)
        {
            HttpRequestMessage request = null;
            if (!string.IsNullOrEmpty(data))
            {
                request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(uri + "/", UriKind.Relative),
                    Content = new StringContent(data, Encoding.UTF8, "application/json")
                };
            }
            else
            {
                request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(uri),
                };
            }
            var response = await client.SendAsync(request);
            return response;
        }

        public static async Task<TResponse> DeleteItemAsync<TResponse>(this HttpClient client, string uri, string data = null)
        {
            var response = await DeleteItemAsync(client, uri, data);
            return await ConvertToModelAsync<TResponse>(response);
        }

        public static async Task<TResponse> PutItemAsync<TResponse>(this HttpClient client, string uri, object request)
        {
            var result = await client.PutAsJsonAsync(uri, request);
            return await ConvertToModelAsync<TResponse>(result);
        }

        private static async Task<TResponse> ConvertToModelAsync<TResponse>(HttpResponseMessage result)
        {
            var str = await result.Content.ReadAsStringAsync();

            var convertedModel = JsonConvert.DeserializeObject<TResponse>(str);
            return convertedModel;
        }
    }
}
