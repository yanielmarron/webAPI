namespace webAPIMovies.Helpers;

public class QueryObject
{
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public string? ActorName { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
