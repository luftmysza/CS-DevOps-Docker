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
        _apiKey = configuration["Omdb:ApiKey"]!;
    }
    public async Task<Movie?> FetchByIdAsync(MovieQuery movieQuery)
    {
        //var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

        var url = "https://www.omdbapi.com/?i=tt3896198&apikey=93ee7c7a";

        OmdbMovie? movieFetched = await _http.GetFromJsonAsync<OmdbMovie>(url);
        Movie? movieMapped = await Mapper(movieFetched);

        throw new NotImplementedException();
        return movieMapped;
    }
    public async Task<Movie?> FetchByTitleAsync(MovieQuery movieQuery)
    {
        //var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

        var url = "https://www.omdbapi.com/?i=tt3896198&apikey=93ee7c7a";

        OmdbMovie? movieFetched = await _http.GetFromJsonAsync<OmdbMovie>(url);
        Movie? movieMapped = await Mapper(movieFetched);

        throw new NotImplementedException();
        return movieMapped;
    }
    public async Task<Movie?> FetchByTypeAsync(MovieQuery movieQuery)
    {
        //var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

        var url = "https://www.omdbapi.com/?i=tt3896198&apikey=93ee7c7a";

        OmdbMovie? movieFetched = await _http.GetFromJsonAsync<OmdbMovie>(url);
        Movie? movieMapped = await Mapper(movieFetched);

        throw new NotImplementedException();
        return movieMapped;
    }
    public async Task<Movie?> FetchBySearchAsync(MovieQuery movieQuery)
    {
        //var url = $"?t={Uri.EscapeDataString(id)}&apikey={_apiKey}";

        var url = "https://www.omdbapi.com/?i=tt3896198&apikey=93ee7c7a";

        OmdbMovie? movieFetched = await _http.GetFromJsonAsync<OmdbMovie>(url);
        Movie? movieMapped = await Mapper(movieFetched);

        throw new NotImplementedException();
        return movieMapped;
    }

    private async Task<Movie?> Mapper(OmdbMovie? movieFetched)
    {
        throw new NotImplementedException();
    }
}