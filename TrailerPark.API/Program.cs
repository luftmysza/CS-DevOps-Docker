using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

using TrailerPark.Core.Services;
using TrailerPark.Core.Interfaces;

using TrailerPark.Intrastructure.Omdb;
using TrailerPark.Infrastructure.Config;
using TrailerPark.Intrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("localDb"));

builder.Services.AddHttpClient<IExternalMovieProvider, OmdbClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Omdb:BaseUrl"]);
});

//builder.Services.AddSingleton<IMovieRepository, MoviesRepo>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

//app.MapGet("test/{title}", async (IExternalMovieProvider omdbClient, string title) =>
//{
//    var movie = await omdbClient.FetchBySearchAsync(title);
//    return movie is null ? Results.NotFound() : Results.Ok(movie);
//});

app.Run();
