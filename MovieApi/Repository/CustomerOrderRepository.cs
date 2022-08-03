using MovieApp.Data;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Repository
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private readonly DataContext _context;

        public CustomerOrderRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCustomerOrder(CustomerOrder customerOrder)
        {
            _context.Add(customerOrder);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
