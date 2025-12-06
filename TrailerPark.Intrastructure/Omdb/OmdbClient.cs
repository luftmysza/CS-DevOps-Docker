using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using TrailerPark.Core.Models;
using TrailerPark.Core.Interfaces;

namespace TrailerPark.Intrastructure.Omdb
{
    public class OmdbClient
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public OmdbClient(HttpClient httpClient, IConfiguration configuration)
        {
            _http = httpClient;
            _apiKey = configuration["Omdb:ApiKey"];
        }

        public async Task<OmdbMovie?> FetchFromOmdbAsync(string id)
        {
            var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

            return await _http.GetFromJsonAsync<OmdbMovie>(url);
        }
    }
}
