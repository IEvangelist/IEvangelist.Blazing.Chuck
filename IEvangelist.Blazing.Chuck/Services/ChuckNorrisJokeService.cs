using IEvangelist.Blazing.Chuck.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEvangelist.Blazing.Chuck.Services
{
    public class ChuckNorrisJokeService : IJokeService
    {
        readonly HttpClient _httpClient;

        public ChuckNorrisJokeService(
            IHttpClientFactory httpClientFactory) =>
            _httpClient =
                httpClientFactory.CreateClient(
                    nameof(ChuckNorrisJokeService));

        async ValueTask<string> IJokeService.GetJokeAsync()
        {
            var result =
                await _httpClient.GetJsonAsync<JokeApiResult>(
                    "http://api.icndb.com/jokes/random?limitTo=[nerdy]");

            return result?.value?.joke ?? "Oops, that didn't work";
        }
    }
}