using Microsoft.EntityFrameworkCore;
using MovieApp.Model;

namespace MovieApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerFavorite> CustomerFavorites { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                    .HasOne(p => p.Movie)
                    .WithMany(pc => pc.MovieActors)
                    .HasForeignKey(p => p.MovieId);
            modelBuilder.Entity<MovieActor>()
                    .HasOne(p => p.Actor)
                    .WithMany(pc => pc.StarredMovies)
                    .HasForeignKey(c => c.ActorId);

            modelBuilder.Entity<CustomerOrder>()
                    .HasOne(p => p.Customer)
                    .WithMany(p => p.PurchasedMovies)
                    .HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<CustomerOrder>()
                    .HasOne(p => p.Movie)
                    .WithMany(p => p.PurchasedCustomers)
                    .HasForeignKey(p => p.MovieId);

            modelBuilder.Entity<CustomerFavorite>()
                    .HasOne(p => p.Customer)
                    .WithMany(p => p.FavoriteGenres)
                    .HasForeignKey(p => p.CustomerId);
            modelBuilder.Entity<CustomerFavorite>()
                    .HasOne(p => p.Genre)
                    .WithMany(p => p.CustomersFavorite)
                    .HasForeignKey(p => p.GenreId);
        }
    }
}
