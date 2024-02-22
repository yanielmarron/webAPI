namespace webAPIMovies.Models;

public class Actor : DeletionMode
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public virtual List<Movie> Movies { get; set; } = [];
}
