using Microsoft.AspNetCore.Mvc;
using webAPIMovies.DAL.Interfaces;
using webAPIMovies.Mappers;

namespace webAPIMovies.Controllers;
[Route("api/actor")]
[ApiController]
public class ActorController(IActorRepository repository) : ControllerBase
{
    private readonly IActorRepository _repository = repository; 

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var actors = await _repository.GetAllAsync();
        var actorDto = actors.Select(actor => actor.ToActorDto());
        return Ok(actorDto);
    }
}
