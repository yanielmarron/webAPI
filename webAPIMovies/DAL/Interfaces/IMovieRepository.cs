using Microsoft.AspNetCore.Mvc;
using webAPIMovies.DTOs;
using webAPIMovies.Helpers;
using webAPIMovies.Models;

namespace webAPIMovies.DAL.Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync(QueryObject queryObject);
    Task<Movie?> GetByIdAsync(int id);
    Task<Movie> AddAsync(Movie movie);
    Task<Movie?> UpdateAsync(int id, UpdateMovieRequestDto movie);
    Task<Movie?> DeleteAsync(int id);
}
