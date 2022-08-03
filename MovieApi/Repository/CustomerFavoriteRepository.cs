using MovieApp.Data;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Repository
{
    public class CustomerFavoriteRepository : ICustomerFavoriteRepository
    {
        private readonly DataContext _context;

        public CustomerFavoriteRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCustomerFavorite(CustomerFavorite customerFavorite)
        {
            _context.Add(customerFavorite);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
