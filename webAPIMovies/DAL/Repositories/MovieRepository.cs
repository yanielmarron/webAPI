using Microsoft.EntityFrameworkCore;
using webAPIMovies.DAL.Interfaces;
using webAPIMovies.Data;
using webAPIMovies.DTOs;
using webAPIMovies.Helpers;
using webAPIMovies.Mappers;
using webAPIMovies.Models;

namespace webAPIMovies.DAL.Repositories;

public class MovieRepository(MovieDBContext context) : IMovieRepository
{
    public readonly MovieDBContext _context = context;

    public async Task<Movie> AddAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie?> DeleteAsync(int id)
    {
        var movieModel = await _context.Movies.FirstOrDefaultAsync(y => y.Id == id);
        if (movieModel is not null)
        {
            movieModel.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        return movieModel;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync(QueryObject queryObject)
    {
        var movies = _context.Movies
                        .Include(x => x.Actors)
                        .AsQueryable();
        if (!string.IsNullOrWhiteSpace(queryObject.Title))
        {
            movies = movies.Where(y => y.Name.Contains(queryObject.Title));
        }
        if (!string.IsNullOrWhiteSpace(queryObject.Genre))
        {
            movies = movies.Where(y => y.Genre.Contains(queryObject.Genre));
        }
        if (!string.IsNullOrWhiteSpace(queryObject.ActorName))
        {
            movies = movies.Where(y => y.Actors.Any(x =>x.Name.Contains(queryObject.ActorName)));
        }
        var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;
        return await movies.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movies.
                        Include(x => x.Actors)
                        .FirstOrDefaultAsync(y => y.Id == id);
    }

    public async Task<Movie?> UpdateAsync(int id, UpdateMovieRequestDto movie)
    {
        var movieModel = await _context.Movies.FirstOrDefaultAsync(y => y.Id == id);
        if (movieModel is not null)
        {
            movieModel.Name = movie.Name;
            movieModel.Year = movie.Year;
            movieModel.Genre = movie.Genre;
            movieModel.Actors = (from item in movie.Actors
                                 select item.ToActor()).ToList();
            await _context.SaveChangesAsync();
        }
        return movieModel;
    }
}
