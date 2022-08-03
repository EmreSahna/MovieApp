using MovieApp.Dto;
using MovieApp.Model;

namespace MovieApp.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        MovieViewWithActorsDto GetMovie(int movieId);
        int GetMoviePriceForOrder(int movieId);
        bool CreateMovie(Movie movie);
        bool UpdateMovie(int movieId, Movie movie);
        bool DeleteMovie(int movieId);
        bool Save();
    }
}
