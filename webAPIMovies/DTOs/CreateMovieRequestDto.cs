namespace webAPIMovies.DTOs;

public class CreateMovieRequestDto
{
    public required string Name { get; init; }
    public int Year { get; set; }
    public required string Genre { get; set; }
    public List<ActorDto>? Actors { get; set; }
}
