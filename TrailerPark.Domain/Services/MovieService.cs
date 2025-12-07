using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TrailerPark.Core.Services;

public class MovieService
{
    /// <summary>
    /// Looks up the film in the database based on the provided search parameter
    /// </summary>
    /// <param name="searchParam"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> IsBufferedAsync(string searchParam)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Inbound(string searchParam)
    {
        throw new NotImplementedException();
    }
}
