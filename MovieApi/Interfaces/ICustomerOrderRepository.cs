using MovieApp.Model;

namespace MovieApp.Interfaces
{
    public interface ICustomerOrderRepository
    {
        bool CreateCustomerOrder(CustomerOrder customerOrder);
        bool Save();
    }
}
