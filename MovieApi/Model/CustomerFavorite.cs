namespace MovieApp.Model
{
    public class CustomerFavorite
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int GenreId { get; set; }
        public Customer Customer { get; set; }
        public Genre Genre { get; set; }
    }
}
