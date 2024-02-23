using webAPIMovies.Models;

namespace webAPIMovies.DAL.Interfaces;

public interface IActorRepository
{
    Task<IEnumerable<Actor>> GetAllAsync();
}
