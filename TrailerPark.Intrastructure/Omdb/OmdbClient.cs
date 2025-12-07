using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using TrailerPark.Core.Models;
using TrailerPark.Core.Interfaces;

namespace TrailerPark.Intrastructure.Omdb;

public class OmdbClient : IExternalMovieProvider
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public OmdbClient(HttpClient httpClient, IConfiguration configuration)
    {
        _http = httpClient;
        _apiKey = configuration["Omdb:ApiKey"];
    }

    public async Task<OmdbMovie?> FetchByIdAsync(string id)
    {
        //var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

        var url = "https://www.omdbapi.com/?i=tt3896198&apikey=93ee7c7a";

        return await _http.GetFromJsonAsync<OmdbMovie>(url);
    }
    public async Task<OmdbMovie?> FetchByTitleAsync(string title)
    {
        //var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

        var url = "https://www.omdbapi.com/?i=tt3896198&apikey=93ee7c7a";

        return await _http.GetFromJsonAsync<OmdbMovie>(url);
    }
    public async Task<OmdbMovie?> FetchByTypeAsync(string type)
    {
        //var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

        var url = "https://www.omdbapi.com/?i=tt3896198&apikey=93ee7c7a";

        return await _http.GetFromJsonAsync<OmdbMovie>(url);
    }
    public async Task<OmdbMovie?> FetchBySearchAsync(string type)
    {
        //var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

        var url = "https://www.omdbapi.com/?i=tt3896198&apikey=93ee7c7a";

        return await _http.GetFromJsonAsync<OmdbMovie>(url);
    }
}