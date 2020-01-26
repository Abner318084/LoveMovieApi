using LoveMovie;
using LoveMovie.Models;
using LoveMovie.Models.Extension;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoveMovieApi
{
    public class TmdbApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppSettings _appSettings;
        private readonly string _apiReadAccessToken;

        public TmdbApiClient(IHttpClientFactory httpClientFactory, IOptionsSnapshot<AppSettings> options, 
            IMemoryCache memoryCache)
        {
            this._httpClientFactory = httpClientFactory;
            this._appSettings = options.Value;
            this._apiReadAccessToken = memoryCache.GetOrCreate(
                CacheKeys.TmdbApiReadAccessToken, 
                entry => File.ReadAllText(this._appSettings.TmdbApiReadAccessTokenFilePath));
        }

        public async Task<TResult> GetAsync<TResult>(string url, IHttpGetRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiReadAccessToken);
            using (var httpResponse = await httpClient.GetAsync(_appSettings.TmdbApiBaseUrl + url + request.ToQueryString())) 
            {
                httpResponse.EnsureSuccessStatusCode();
                var json = await httpResponse.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TResult>(json);
            }                
        }

    }
}
