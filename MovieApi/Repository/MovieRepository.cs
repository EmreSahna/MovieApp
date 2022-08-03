using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MovieRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public MovieViewWithActorsDto GetMovie(int movieId)
        {
            var result = _mapper.Map<MovieViewDto>(_context.Movies.Include(x => x.Director).Include(x => x.Genre).Where(x => x.MovieId == movieId).FirstOrDefault());

            var movie = _context.Movies.Where(n => n.MovieId == movieId).Select(movie => new MovieViewWithActorsDto()
            {
                Name = movie.Name,
                Price = movie.Price,
                RelaseDate = movie.RelaseDate,
                Genre = result.Genre,
                Director = result.Director,
                Actors = movie.MovieActors.Select(x => (x.Actor.Name + " " + x.Actor.Surname)).ToList()
            }).FirstOrDefault();
            return movie;
        }

        public bool CreateMovie(Movie movie)
        {
            _context.Add(movie);
            return Save();
        }

        public bool UpdateMovie(int movieId, Movie movie)
        {
            var oldmovie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);
            oldmovie.Name = movie.Name;
            oldmovie.RelaseDate = movie.RelaseDate;
            oldmovie.Director = movie.Director;
            oldmovie.Genre = movie.Genre;
            oldmovie.Price = movie.Price;
            return Save();
        }

        public bool DeleteMovie(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(n => n.MovieId == movieId);
            _context.Remove(movie);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public int GetMoviePriceForOrder(int movieId)
        {
            var movie = _context.Movies.Where(x => x.MovieId == movieId).FirstOrDefault();
            return movie.Price;
        }
    }
}
