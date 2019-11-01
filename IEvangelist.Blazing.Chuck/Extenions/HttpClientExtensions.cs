using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEvangelist.Blazing.Chuck
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient client, string requestUrl)
        {
            var json = await client.GetStringAsync(requestUrl);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}