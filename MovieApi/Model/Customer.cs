namespace MovieApp.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public ICollection<CustomerFavorite> FavoriteGenres { get; set; }
        public ICollection<CustomerOrder> PurchasedMovies { get; set; }
    }
}
