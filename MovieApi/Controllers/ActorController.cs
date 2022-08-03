using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IMapper _mapper;
        public ActorController(IActorRepository actorRepository, IMapper mapper, IMovieActorRepository movieActorRepository)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
            _movieActorRepository = movieActorRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Actor>))]
        public IActionResult GetActors()
        {
            var actors = _mapper.Map<List<ActorViewDto>>(_actorRepository.GetActors());
            return Ok(actors);
        }

        [HttpGet("{actorId}")]
        public IActionResult GetActorWithMovies(int actorId)
        {
            var actor = _actorRepository.GetActor(actorId);
            return Ok(actor);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateActor([FromBody] ActorDto actorCreate)
        {
            var actorMap = _mapper.Map<Actor>(actorCreate);

            _actorRepository.CreateActor(actorMap);
            
            foreach (var id in actorCreate.MovieIds)
            {
                var rel = new MovieActor()
                {
                    MovieId = id,
                    ActorId = actorMap.ActorId
                };
                _movieActorRepository.CreateMovieActor(rel);
            }
            
            return Ok("Successfully created");
        }

        [HttpPut("{actorId}")]
        public IActionResult UpdateActor(int actorId, [FromBody] ActorUpdateDto movieUpdate)
        {
            var actorMap = _mapper.Map<Actor>(movieUpdate);
            _actorRepository.UpdateActor(actorId, actorMap);
            return Ok();
        }

        [HttpDelete("{actorId}")]
        public IActionResult DeleteActor(int actorId)
        {
            if (_actorRepository.DeleteActor(actorId))
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
