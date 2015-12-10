using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shortcut.DeepLinking.Pcl
{
    internal static class ClientExtensions
    {
        internal static async Task<HttpResponseMessage> ExecutePostDataAsJsonAsync<T>(this HttpClient client, string url, T data)
        {
            HttpContent postData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, postData);
            response.EnsureSuccessStatusCode();
            return response;
        }

        internal static string GetResult(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }

        internal static void EnsureNotNullOrEmpty(this string inputstring)
        {
            if (string.IsNullOrWhiteSpace(inputstring))
                throw new ArgumentException("String value is null or empty!");
        }
    }
}
