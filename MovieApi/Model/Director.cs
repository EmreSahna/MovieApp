namespace MovieApp.Model
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Movie> DirectedMovies { get; set; }
    }
}
