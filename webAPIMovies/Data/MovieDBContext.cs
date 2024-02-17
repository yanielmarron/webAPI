using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using webAPIMovies.Models;

namespace webAPIMovies.Data;

public class MovieDBContext(DbContextOptions<MovieDBContext> options) : DbContext(options)
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Actor>().HasKey(y => y.Id);
        modelBuilder.Entity<Actor>().Property(y => y.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Actor>().Property(y => y.Name).HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Movie>().HasKey(y => y.Id);
        modelBuilder.Entity<Movie>().Property(y => y.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Movie>().Property(y => y.Name).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Movie>().Property(y => y.Year).IsRequired();
        modelBuilder.Entity<Movie>().Property(y => y.Genre).IsRequired();
        modelBuilder.Entity<Movie>().HasMany(y => y.Actors);
    }
}