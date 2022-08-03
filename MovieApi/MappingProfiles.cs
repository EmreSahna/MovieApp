using AutoMapper;
using MovieApp.Dto;
using MovieApp.Model;

namespace MovieApp
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Movie
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieViewDto>();
            CreateMap<Movie, MoviesViewDto>();
            CreateMap<Movie, MovieUpdateDto>();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<MovieViewDto, MovieViewWithActorsDto>();
            
            //Genre
            CreateMap<GenreDto, Genre>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Genre, GenreViewDto>();
            CreateMap<GenreUpdateDto, Genre>();
            
            //Actor
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();
            CreateMap<Actor, ActorViewDto>();
            CreateMap<ActorUpdateDto, Actor>();

            //Director
            CreateMap<Director, DirectorDto>();
            CreateMap<DirectorDto, Director>();
            CreateMap<DirectorUpdateDto, Director>();

            //Customer
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, CreateCustomerDto>();
        }
    }
}
