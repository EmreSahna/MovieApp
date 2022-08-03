namespace MovieApp.Model
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<CustomerFavorite> CustomersFavorite { get; set; }
    }
}
