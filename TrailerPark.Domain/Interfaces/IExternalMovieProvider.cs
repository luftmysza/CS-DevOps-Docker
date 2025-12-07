using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerPark.Core.Models;

namespace TrailerPark.Core.Interfaces;

public interface IExternalMovieProvider
{
    public Task<OmdbMovie?> FetchByTitleAsync(string id);
    public Task<OmdbMovie?> FetchByIdAsync(string title);
    public Task<OmdbMovie?> FetchByTypeAsync(string type);
    public Task<OmdbMovie?> FetchBySearchAsync(string query);
}
