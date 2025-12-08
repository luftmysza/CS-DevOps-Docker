using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using TrailerPark.Core.Models;
using TrailerPark.Core.Interfaces;
using TrailerPark.Infrastructure.Config;

namespace TrailerPark.Intrastructure.Repositories;

public class MoviesRepo : IMovieRepository
{
    private readonly AppDbContext _context;
    public MoviesRepo(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Movie?> GetByIdAsync(MovieQuery movieQuery)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.imdbID == movieQuery.imdbID);
    }
    public async Task<Movie?> GetBySearchAsync(MovieQuery movieQuery)
    {
        Movie? movie = null;
        movie = await _context.Movies.FirstOrDefaultAsync(m => m.imdbID == movieQuery.imdbID);
        movie = await _context.Movies.FirstOrDefaultAsync(m => m.imdbID == movieQuery.imdbID);

        throw new NotImplementedException();
    }
    // public async Task<Movie?> GetByTitleAsync(string title)
    // {
    //     return await _context.Movies.FirstOrDefaultAsync(m => m.Title == title);
    // }
    // public async Task<Movie?> GetByTypeAsync(string type)
    // {
    //     return await _context.Movies.FirstOrDefaultAsync(m => m.Type == type);
    // }
    public async Task<bool> AddAsync(Movie movie)
    {   
        EntityEntry<Movie>  movieStaged = await _context.Movies.AddAsync(movie);
        int count = await _context.SaveChangesAsync();

        if (count > 0 && movieStaged is not null) return true;

        return false;
    }
}