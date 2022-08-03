using MovieApp.Model;

namespace MovieApp.Dto
{
    public class MovieDto
    {
        public string Name { get; set; }
        public DateTime RelaseDate { get; set; }
        public int Price { get; set; }
        public List<int> ActorIds { get; set; }
    }
    public class MovieViewDto
    {
        public DateTime RelaseDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DirectorDto Director { get; set; }
        public GenreDto Genre { get; set; }

    }
    public class MovieViewWithActorsDto
    {
        public DateTime RelaseDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DirectorDto Director { get; set; }
        public GenreDto Genre { get; set; }
        public List<string> Actors { get; set; }
    }
    public class MoviesViewDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime RelaseDate { get; set; }
    }
    public class MovieUpdateDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime RelaseDate { get; set; }
    }
}
