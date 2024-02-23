using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPIMovies.Data;
using webAPIMovies.DTOs;
using webAPIMovies.Mappers;
using webAPIMovies.Models;
using System.Linq;
using webAPIMovies.DAL.Interfaces;
using webAPIMovies.Helpers;

namespace webAPIMovies.Controllers;
[Route("api/movie")]
public class MovieController : ControllerBase
{
    private readonly IMovieRepository _repository;
    public MovieController(IMovieRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]QueryObject queryObject)
    {
        var movies = await _repository.GetAllAsync(queryObject);
        var movieDto = movies.Select(movie => movie.ToMovieDto()).AsQueryable();
        return Ok(movieDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var movie = await _repository.GetByIdAsync(id);
        if (movie is null)
        {
            return NotFound();
        }
        return Ok(movie.ToMovieDto());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]CreateMovieRequestDto movieDto)
    {
        var movieModel = await _repository.AddAsync(movieDto.ToMovieFromCreateMovieDto());
        return CreatedAtAction(nameof(GetById), new {id = movieModel.Id }, movieModel.ToMovieDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute]int id, [FromBody]UpdateMovieRequestDto movie)
    {
        var movieModel = await _repository.UpdateAsync(id, movie);
        if (movieModel is null)
        {
            return NotFound();
        }
        return Ok(movieModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete([FromRoute]int id)
    {
        var movieModel = await _repository.DeleteAsync(id);
        if (movieModel is null)
        {
            return NotFound();
        }
        return NoContent();
    }
}   
