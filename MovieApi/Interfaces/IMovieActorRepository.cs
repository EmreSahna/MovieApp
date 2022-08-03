using MovieApp.Model;

namespace MovieApp.Interfaces
{
    public interface IMovieActorRepository
    {
        bool CreateMovieActor(MovieActor movieActor);
        bool Save();
    }
}
