namespace webAPIMovies.DTOs;

public class UpdateMovieRequestDto
{
    public required string Name { get; init; }
    public int Year { get; set; }
    public required string Genre { get; set; }
    public required List<ActorDto> Actors { get; set; }
}
