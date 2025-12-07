using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using TrailerPark.Core.Models;
using TrailerPark.Core.Interfaces;
using TrailerPark.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace TrailerPark.Intrastructure.Repositories;

public class MoviesRepo : IMovieRepository
{
    private readonly AppDbContext _context;

    public MoviesRepo(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Movie?> GetByIdAsync(string id)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.imdbID == id);
    }
    public async Task<Movie?> GetBySearchAsync(string query)
    {
        throw new NotImplementedException();
    }
    public async Task<Movie?> GetByTitleAsync(string title)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.Title == title);
    }
    public async Task<Movie?> GetByTypeAsync(string type)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.Type == type);
    }
}