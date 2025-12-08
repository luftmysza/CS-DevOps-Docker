using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using TrailerPark.Core.Models;

namespace TrailerPark.Core.Interfaces;

public interface IMovieRepository
{
    public Task<Movie?> GetBySearchAsync(MovieQuery movieQuery);
    public Task<Movie?> GetByIdAsync(MovieQuery movieQuery);
    // public Task<Movie?> GetByTypeAsync(MovieQuery movieQuery);
    // public Task<Movie?> GetBySearchAsync(MovieQuery movieQuery);
    public Task<bool> AddAsync(Movie movie);
}