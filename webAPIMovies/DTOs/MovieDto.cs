namespace webAPIMovies.DTOs;

public record MovieDto(int Id, string Name, int Year, string Genre, List<ActorDto> Actors)
{
    public int Year { get; set; } = Year;
    public required string Genre { get; set; } = Genre;
    public virtual List<ActorDto>? Actors { get; set; } = Actors;
}
