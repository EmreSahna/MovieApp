using MovieApp.Dto;
using MovieApp.Model;

namespace MovieApp.Interfaces
{
    public interface IDirectorRepository
    {
        ICollection<Director> GetDirectors();
        DirectorWithMoviesDto GetDirector(int id);
        Director GetDirectorById(int id);
        bool CreateDirector(Director director);
        bool UpdateDirector(int directorId, Director director);
        bool DeleteDirector(int directorId);
        bool Save();
    }
}
