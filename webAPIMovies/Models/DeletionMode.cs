using System.Data;

namespace webAPIMovies.Models;
public abstract class DeletionMode
{
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? DeleteOn { get; set; }
    public bool IsDeleted { get; set; }
}