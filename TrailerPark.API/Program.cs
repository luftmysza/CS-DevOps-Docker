using TrailerPark.Intrastructure.Omdb;
using TrailerPark.Core.Interfaces;
using TrailerPark.Core.Services;
using TrailerPark.Intrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<OmdbClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Omdb:BaseUrl"]);
});

builder.Services.AddSingleton<IMovieRepository, MoviesRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/movies/{title}", async (MovieService service, string title) =>
{
    var movie = await service.GetOrFetchMovieAsync(title);
    return movie is null ? Results.NotFound() : Results.Ok(movie);
});


app.Run();
