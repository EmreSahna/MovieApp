using MovieApp.Data;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.TokenAuth;
using MovieApp.TokenAuth.Models;

namespace MovieApp.Repository
{
    public class TokenAuthRepository : ITokenAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public TokenAuthRepository(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Token CreateTokenHandler(CustomerLoginDto customer)
        {
            var customerIs = _context.Customers.FirstOrDefault(x => x.Name == customer.Name && x.Surname == customer.Surname);

            if(customerIs is null)
            {
                throw new InvalidOperationException("Giriş yaptığınız kullanıcı bulunamadi.");
            }

            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccesToken(customerIs);

            customerIs.RefreshToken = token.RefreshToken;
            customerIs.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

            Save();
            return token;
        }

        public Token RefreshTokenHandler(string RefreshToken)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);

            if (customer is null)
            {
                throw new InvalidOperationException("Geçersiz.");
            }

            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccesToken(customer);

            customer.RefreshToken = token.RefreshToken;
            customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

            Save();
            return token;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
