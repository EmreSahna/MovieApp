using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly DataContext _context;
        public ActorRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateActor(Actor actor)
        {
            _context.Add(actor);
            return Save();
        }
        public ActorViewWithMoviesDto GetActor(int actorId)
        {
            var actor = _context.Actors.Where(n => n.ActorId == actorId).Select(actor => new ActorViewWithMoviesDto()
            {
                Name = actor.Name,
                Surname = actor.Surname,
                Movies = actor.StarredMovies.Select(x => x.Movie.Name).ToList()
            }).FirstOrDefault();

            if(actor == null)
            {
                throw new InvalidOperationException("Aktör bulunamadı.");
            }

            return actor;
        }

        public bool UpdateActor(int actorId, Actor actor)
        {
            var oldActor = _context.Actors.FirstOrDefault(x => x.ActorId == actorId);

            if(oldActor == null)
            {
                throw new InvalidOperationException("Güncellenecek aktör bulunamadı.");
            }

            oldActor.Name = actor.Name;
            oldActor.Surname = actor.Surname;

            return Save();
        }

        public bool DeleteActor(int actorId)
        {
            var actor = _context.Actors.FirstOrDefault(n => n.ActorId == actorId);
            if(actor == null)
            {
                throw new InvalidOperationException("Silinecek aktör bulunamadi.");
            }
            _context.Remove(actor);
            return Save();
        }

        public ICollection<Actor> GetActors()
        {
            return _context.Actors.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
