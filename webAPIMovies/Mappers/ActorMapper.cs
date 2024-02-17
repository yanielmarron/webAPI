using webAPIMovies.DTOs;
using webAPIMovies.Models;

namespace webAPIMovies.Mappers;

public static class ActorMapper
{
    public static ActorDto ToActorDto(this Actor actorModel)
    {
        return new ActorDto(actorModel.Id, actorModel.Name);
    }

    public static Actor ToActor(this ActorDto actorModel)
    {
        return new Actor
        {
            Id = actorModel.Id,
            Name = actorModel.Name
        };
    }
}
