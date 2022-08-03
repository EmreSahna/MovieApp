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
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
        public IActionResult GetGenres()
        {
            var genres = _mapper.Map<List<GenreViewDto>>(_genreRepository.GetGenres());
            return Ok(genres);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGenre([FromBody]GenreDto genreCreate)
        {
            var genreMap = _mapper.Map<Genre>(genreCreate);

            if (!_genreRepository.CreateGenre(genreMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{genreId}")]
        public IActionResult UpdateGenre(int genreId, [FromBody] GenreUpdateDto genreUpdate)
        {
            var genreMap = _mapper.Map<Genre>(genreUpdate);
            _genreRepository.UpdateGenre(genreId, genreMap);
            return Ok();
        }

        [HttpDelete("{genreId}")]
        public IActionResult DeleteGenre(int genreId)
        {
            _genreRepository.DeleteGenre(genreId);
            return Ok();
        }

        [HttpGet("{genreId}")]
        public IActionResult GetGenreWithMovies(int genreId)
        {
            var genre = _genreRepository.GetGenre(genreId);
            return Ok(genre);
        }
    }
}
