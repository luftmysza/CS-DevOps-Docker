using System.Collections.Generic;
using System.ComponentModel.Design;

using Microsoft.EntityFrameworkCore;

using TrailerPark.Core.Models;

namespace TrailerPark.Infrastructure.Config;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Person> People { get; set; }
}
