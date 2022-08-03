namespace MovieApp.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public DateTime RelaseDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Director Director { get; set; }
        public Genre Genre { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<CustomerOrder> PurchasedCustomers { get; set; }
    }
}
