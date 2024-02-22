namespace webAPIMovies.Models;

public class Movie : DeletionMode
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Year { get; set; }
    public required string Genre { get; set; }
    public virtual List<Actor> Actors { get; set; } = [];
}
