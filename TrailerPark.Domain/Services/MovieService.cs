using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using TrailerPark.Core.Models;
using TrailerPark.Core.Interfaces;
using System.Runtime.Serialization;

namespace TrailerPark.Core.Services;

public class MovieService
{
    private readonly IMovieRepository _movieRepo;
    private readonly IExternalMovieProvider _omdbClient;
    public MovieService(IMovieRepository movieRepo, IExternalMovieProvider omdbClient)
    {
        _movieRepo = movieRepo;
        _omdbClient = omdbClient;
    }
    public async Task<Movie?> Inbound(MovieQuery movieQuery)
    {
        Movie? movieLocal = null;
        Movie? movieFetched = null;
        Movie? movie;

        movieLocal = await GetLocalAsync(movieQuery);
        if (movieLocal is null)
        {
            movieFetched = await FetchOmdbAsync(movieQuery);
            if (movieFetched is not null)
            {
                bool ok = await _movieRepo.AddAsync(movieFetched);
                if (!ok)
                    return null;
                movie = movieFetched;
            }
        }

        throw new NotImplementedException();
        return movie;     
    }
    public async Task<Movie?> GetLocalAsync(MovieQuery movieQuery)
    {
        Movie? movieLocal = null;
        if (movieQuery.imdbID is not null)
            movieLocal = await _movieRepo.GetByIdAsync(movieQuery);
        else if (movieQuery.SearchString is not null)
            movieLocal = await _movieRepo.GetBySearchAsync(movieQuery);

        return movieLocal;
    }
    public async Task<Movie?> FetchOmdbAsync(MovieQuery movieQuery)
    {
        Movie? movieFetched = null;
        if (movieQuery.imdbID is not null)
            movieFetched = await _omdbClient.FetchByIdAsync(movieQuery);
        else if (movieQuery.SearchString is not null)
            movieFetched = await _omdbClient.FetchBySearchAsync(movieQuery);

        return movieFetched;
    }
}