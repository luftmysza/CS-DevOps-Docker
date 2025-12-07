using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using TrailerPark.Core.Models;

namespace TrailerPark.Core.Interfaces;

public interface IMovieRepository
{
    public Task<Movie?> GetByTitleAsync(string id);
    public Task<Movie?> GetByIdAsync(string title);
    public Task<Movie?> GetByTypeAsync(string type);
    public Task<Movie?> GetBySearchAsync(string query);

}
