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
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;
        public MovieController(IMovieRepository movieRepository, IMapper mapper, IGenreRepository genreRepository, IDirectorRepository directorRepository, IMovieActorRepository movieActorRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _genreRepository = genreRepository;
            _directorRepository = directorRepository;
            _movieActorRepository = movieActorRepository;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _mapper.Map<List<MoviesViewDto>>(_movieRepository.GetMovies());
            return Ok(movies);
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMovieWithActors(int movieId)
        {
            var movie = _movieRepository.GetMovie(movieId);
            return Ok(movie);
        }


        [HttpPost]
        public IActionResult CreateMovie([FromQuery] int directorId, [FromQuery] int genreId,[FromBody]MovieDto movieCreate)
        {
            
            var movieMap = _mapper.Map<Movie>(movieCreate);
            movieMap.Genre = _genreRepository.GetGenreById(genreId);
            movieMap.Director = _directorRepository.GetDirectorById(directorId);

            _movieRepository.CreateMovie(movieMap);
            

            foreach (var id in movieCreate.ActorIds)
            {
                var rel = new MovieActor()
                {
                    MovieId = movieMap.MovieId,
                    ActorId = id
                };
                _movieActorRepository.CreateMovieActor(rel);
            }
            
            return Ok("Successfully created");
        }

        [HttpPut("{movieId}")]
        public IActionResult UpdateMovie(int movieId, [FromQuery] int directorId, [FromQuery] int genreId, [FromBody] MovieUpdateDto movieUpdate)
        {
            var movieMap = _mapper.Map<Movie>(movieUpdate);
            movieMap.Genre = _genreRepository.GetGenreById(genreId);
            movieMap.Director = _directorRepository.GetDirectorById(directorId);

            _movieRepository.UpdateMovie(movieId,movieMap);

            return Ok();
        }

        [HttpDelete("{movieId}")]
        public IActionResult DeleteMovie(int movieId)
        {
            _movieRepository.DeleteMovie(movieId);
            return Ok();
        }
    }
}
