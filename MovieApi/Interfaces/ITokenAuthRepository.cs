using MovieApp.Dto;
using MovieApp.TokenAuth.Models;

namespace MovieApp.Interfaces
{
    public interface ITokenAuthRepository
    {
        Token CreateTokenHandler(CustomerLoginDto customer);
        Token RefreshTokenHandler(string RefreshToken);
        bool Save();
    }
}
