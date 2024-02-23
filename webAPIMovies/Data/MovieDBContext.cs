using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using webAPIMovies.Data.EntityConfiguration;
using webAPIMovies.Models;

namespace webAPIMovies.Data;

public class MovieDBContext(DbContextOptions<MovieDBContext> options) : DbContext(options)
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AutorEntityConfiguration());
    }
}