using MovieApp.Model;

namespace MovieApp.Interfaces
{
    public interface ICustomerFavoriteRepository
    {
        bool CreateCustomerFavorite(CustomerFavorite customerFavorite);
        bool Save();
    }
}
