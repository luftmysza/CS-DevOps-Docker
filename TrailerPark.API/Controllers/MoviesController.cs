using Microsoft.AspNetCore.Mvc;
using TrailerPark.Core.Interfaces;
using TrailerPark.Intrastructure.Omdb;

namespace TrailerPark.API.Controllers;

[Route("/")]
public class MoviesController : ControllerBase
{
    public IExternalMovieProvider _omdbClient;

    public MoviesController(IExternalMovieProvider omdbClient)
    {
        _omdbClient = omdbClient;
    }


    [HttpGet("{query}")]
    public async Task<IActionResult> Index([FromRoute] string query)
    {
        var result = await _omdbClient.FetchByIdAsync(query);
        return Ok();
    }
}
