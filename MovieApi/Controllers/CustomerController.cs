using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Dto;
using MovieApp.Interfaces;
using MovieApp.Model;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerOrderRepository _customerOrderRepository;
        private readonly ICustomerFavoriteRepository _customerFavoriteRepository;
        private readonly ITokenAuthRepository _tokenAuthRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository, ICustomerOrderRepository customerOrderRepository, ICustomerFavoriteRepository customerFavoriteRepository, IMovieRepository movieRepository, ITokenAuthRepository tokenAuthRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerOrderRepository = customerOrderRepository;
            _customerFavoriteRepository = customerFavoriteRepository;
            _movieRepository = movieRepository;
            _tokenAuthRepository = tokenAuthRepository;
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCustomerWithDetails(int customerId)
        {
            var customer = _customerRepository.GetCustomerWithDetails(customerId);
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CreateCustomerDto customerCreate)
        {
            var customerMap = _mapper.Map<Customer>(customerCreate);
            _customerRepository.CreateCustomer(customerMap);

            foreach (var id in customerCreate.Purchased)
            {
                var moviePrice = _movieRepository.GetMoviePriceForOrder(id);
                var rel = new CustomerOrder()
                {
                    MovieId = id,
                    CustomerId = customerMap.CustomerId,
                    Price = moviePrice,
                    PurchasedDate = DateTime.Now,
                };
                _customerOrderRepository.CreateCustomerOrder(rel);
            }

            foreach (var id in customerCreate.Favorite)
            {
                var rel = new CustomerFavorite()
                {
                    GenreId = id,
                    CustomerId = customerMap.CustomerId
                };
                _customerFavoriteRepository.CreateCustomerFavorite(rel);
            }

            return Ok("Successfully created");
        }

        [Authorize]
        [HttpPost]
        [Route("buy/{customerId}")]
        public IActionResult CreatePurchase(int customerId, [FromBody]CustomerPurchaseMovie customerCreateOrder)
        {
            foreach (var id in customerCreateOrder.Purchased)
            {
                var moviePrice = _movieRepository.GetMoviePriceForOrder(id);
                var rel = new CustomerOrder()
                {
                    MovieId = id,
                    CustomerId = customerId,
                    Price = moviePrice,
                    PurchasedDate = DateTime.Now,
                };
                _customerOrderRepository.CreateCustomerOrder(rel);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
            return Ok();
        }

        [HttpPost("connect/token")]
        public IActionResult CreateToken([FromBody] CustomerLoginDto login)
        {
            var token = _tokenAuthRepository.CreateTokenHandler(login);

            return Ok(token);
        }

        [HttpGet("refreshToken")]
        public IActionResult RefreshToken([FromQuery] string token)
        {
            var refreshToken = _tokenAuthRepository.RefreshTokenHandler(token);

            return Ok(refreshToken);
        }
    }
}
