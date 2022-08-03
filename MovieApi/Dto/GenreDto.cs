namespace MovieApp.Dto
{
    public class GenreDto
    {
        public string GenreName { get; set; }
    }

    public class GenreViewDto
    {
        public string GenreName { get; set; }
        public ICollection<MovieDto> Movies { get; set; }
    }
    public class GenreWithMoviesDto
    {
        public string GenreName { get; set; }
        public List<string> Movies { get; set; }
    }
    public class GenreUpdateDto
    {
        public string GenreName { get; set; }
    }
}
