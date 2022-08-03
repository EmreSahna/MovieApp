using MovieApp.Dto;
using MovieApp.Model;

namespace MovieApp.Interfaces
{
    public interface ICustomerRepository
    {
        CustomerViewWithDetailsDto GetCustomerWithDetails(int customerId);
        bool CreateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        bool Save();
    }
}
