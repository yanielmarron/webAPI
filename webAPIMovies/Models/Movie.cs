namespace webAPIMovies.Models;

public class Movie : DeletionMode
{
    private List<Actor>? actors = new List<Actor>();

    public int Id { get; init; }
    public required string Name { get; init; }
    public int Year { get; set; }
    public required string Genre { get; set; }
    public virtual List<Actor>? Actors { get => actors; set => actors = value; }
}
