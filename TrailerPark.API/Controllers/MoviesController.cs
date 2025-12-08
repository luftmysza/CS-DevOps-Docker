using Microsoft.AspNetCore.Mvc;

using TrailerPark.Core.Models;
using TrailerPark.Core.Services;
using TrailerPark.Core.Interfaces;


namespace TrailerPark.API.Controllers;

[ApiController]
[Route("/")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _service;

    public MoviesController(MovieService service)
    {
         _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] MovieQuery movieQuery)
    {   
        if (movieQuery is null) 
            return BadRequest("Provided parameters do not meet API requirements");

        Movie? result = await _service.Inbound(movieQuery);

        if (result is null)
            return NotFound("Provided parameters did not return any result");
        else
            return Ok(result);
    }
}