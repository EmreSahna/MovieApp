using MovieApp.Data;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Repository
{
    public class MovieActorRepository : IMovieActorRepository
    {
        private readonly DataContext _context;

        public MovieActorRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateMovieActor(MovieActor movieActor)
        {
            _context.Add(movieActor);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
