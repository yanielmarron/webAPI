using webAPIMovies.DTOs;
using webAPIMovies.Models;
using System.Linq;

namespace webAPIMovies.Mappers;

public static class MovieMapper
{
    public static MovieDto ToMovieDto(this Movie movieModel)
    {
        var actors = (from item in movieModel.Actors
                      select item.ToActorDto()).ToList();
        return new MovieDto(movieModel.Id, movieModel.Name, movieModel.Year, movieModel.Genre, actors)
        {
            Genre = movieModel.Genre
        };
    }

    public static Movie ToMovieFromCreateMovieDto(this CreateMovieRequestDto movieDto)
    {
        var actors = (from item in movieDto.Actors
                        select item.ToActor()).ToList();
        return new Movie
        {
            Name = movieDto.Name,
            Year = movieDto.Year,
            Genre = movieDto.Genre,
            Actors = actors
        };
    }
}
