using Microsoft.EntityFrameworkCore;
using webAPIMovies.DAL.Interfaces;
using webAPIMovies.Data;
using webAPIMovies.Models;

namespace webAPIMovies.DAL.Repositories;

public class ActorRepository(MovieDBContext context) : IActorRepository
{
    public readonly MovieDBContext _context = context;

    public async Task<IEnumerable<Actor>> GetAllAsync()
    {
        return await _context.Actors.ToListAsync();
    }
    
}
