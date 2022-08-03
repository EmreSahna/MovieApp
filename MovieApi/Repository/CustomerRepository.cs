using FluentValidation;
using MovieApp.Data;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        public CustomerViewWithDetailsDto GetCustomerWithDetails(int customerId)
        {
            var customer = _context.Customers.Where(n => n.CustomerId == customerId).Select(customer => new CustomerViewWithDetailsDto()
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Favorite = customer.FavoriteGenres.Select(x => x.Genre.GenreName).ToList(),
                Purchased = customer.PurchasedMovies.Select(x => x.Movie.Name).ToList()
            }).FirstOrDefault();

            if(customer == null)
            {
                throw new InvalidOperationException("Aradığınız müşteri bulunamadi.");
            }

            return customer;
        }

        public bool CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(n => n.CustomerId == customerId);

            if(customer == null)
            {
                throw new InvalidOperationException("Silinmek istenen müşteri bulunamadi.");
            }

            _context.Remove(customer);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
