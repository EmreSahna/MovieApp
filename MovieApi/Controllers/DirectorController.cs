using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;
        public DirectorController(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Director>))]
        public IActionResult GetDirectors()
        {
            var directors = _mapper.Map<List<DirectorDto>>(_directorRepository.GetDirectors());
            return Ok(directors);
        }

        [HttpGet("{directorId}")]
        public IActionResult GetDirectorWithMovies(int directorId)
        {
            var actor = _directorRepository.GetDirector(directorId);
            return Ok(actor);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDirector([FromBody] DirectorDto directorCreate)
        {
            var directorMap = _mapper.Map<Director>(directorCreate);

            if (!_directorRepository.CreateDirector(directorMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{directorId}")]
        public IActionResult UpdateDirector(int directorId, [FromBody] DirectorUpdateDto directorUpdate)
        {
            var directorMap = _mapper.Map<Director>(directorUpdate);
            _directorRepository.UpdateDirector(directorId, directorMap);
            return Ok();
        }

        [HttpDelete("{directorId}")]
        public IActionResult DeleteDirector(int directorId)
        {
            _directorRepository.DeleteDirector(directorId);
            return Ok();
        }
    }
}
