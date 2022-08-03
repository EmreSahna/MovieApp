using MovieApp.Dto;
using MovieApp.Model;

namespace MovieApp.Interfaces
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();
        GenreWithMoviesDto GetGenre(int id);
        Genre GetGenreById(int genreId);
        bool CreateGenre(Genre genre);
        bool UpdateGenre(int genreId, Genre genre);
        bool DeleteGenre(int genreId);
        bool Save();
        
       
    }
}
