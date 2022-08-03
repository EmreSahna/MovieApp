using AutoMapper;
using MovieApp.Data;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DataContext _context;

        public DirectorRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateDirector(Director director)
        {
            _context.Add(director);
            return Save();
        }

        public ICollection<Director> GetDirectors()
        {
            return _context.Directors.OrderBy(m => m.DirectorId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public DirectorWithMoviesDto GetDirector(int directorId)
        {
            var director = _context.Directors.Where(n => n.DirectorId == directorId).Select(director => new DirectorWithMoviesDto()
            {
                Name = director.Name,
                Surname = director.Surname,
                Movies = director.DirectedMovies.Select(x => x.Name).ToList()
            }).FirstOrDefault();

            if(director == null)
            {
                throw new InvalidOperationException("Aradığınız yönetmen bulunamadi.");
            }

            return director;
        }

        public bool UpdateDirector(int directorId, Director director)
        {
            var oldDirector = _context.Directors.FirstOrDefault(x => x.DirectorId == directorId);

            if (director == null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz yönetmen bulunamadi.");
            }

            oldDirector.Name = director.Name;
            oldDirector.Surname = director.Surname;
            return Save();
        }

        public bool DeleteDirector(int directorId)
        {
            var director = _context.Directors.FirstOrDefault(n => n.DirectorId == directorId);

            if (director == null)
            {
                throw new InvalidOperationException("Silmek istediğiniz yönetmen bulunamadi.");
            }

            _context.Remove(director);
            return Save();
        }

        public Director GetDirectorById(int id)
        {
            var director = _context.Directors.Where(x => x.DirectorId == id).FirstOrDefault();
            if(director == null)
            {
                throw new InvalidOperationException("Aradığınız yönetmen bulunamadi.");
            }
            return director;
        }
    }
}
