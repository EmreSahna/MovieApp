using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateGenre(Genre genre)
        {
            _context.Add(genre);
            return Save();
        }

        public Genre GetGenreById(int id)
        {
            var genre = _context.Genres.Where(x => x.GenreId == id).FirstOrDefault();

            if (genre == null)
            {
                throw new InvalidOperationException("Aradığınız tür bulunamadi.");
            }

            return genre;
        }

        public ICollection<Genre> GetGenres()
        {
            return _context.Genres.Include(x => x.Movies).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateGenre(int genreId, Genre genre)
        {
            var oldGenre = _context.Genres.FirstOrDefault(x => x.GenreId == genreId);

            if (oldGenre == null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz tür bulunamadi.");
            }

            oldGenre.GenreName = genre.GenreName;
            return Save();
        }

        public bool DeleteGenre(int genreId)
        {
            var genre = _context.Genres.FirstOrDefault(n => n.GenreId == genreId);
            if (genre == null)
            {
                throw new InvalidOperationException("Silmek istediğiniz tür bulunamadi.");
            }
            _context.Remove(genre);

            return Save();
        }

        public GenreWithMoviesDto GetGenre(int id)
        {
            var genre = _context.Genres.Where(n => n.GenreId == id).Select(genre => new GenreWithMoviesDto()
            {
                GenreName = genre.GenreName,
                Movies = genre.Movies.Select(x => x.Name).ToList()
            }).FirstOrDefault();

            if (genre == null)
            {
                throw new InvalidOperationException("Aradığınız tür bulunamadi.");
            }

            return genre;
        }
    }
}
