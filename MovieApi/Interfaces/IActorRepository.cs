using MovieApp.Dto;
using MovieApp.Model;

namespace MovieApp.Interfaces
{
    public interface IActorRepository
    {
        ICollection<Actor> GetActors();
        ActorViewWithMoviesDto GetActor(int actorId);
        bool CreateActor(Actor actor);
        bool UpdateActor(int actorId, Actor actor);
        bool DeleteActor(int actorId);
        bool Save();
    }
}
