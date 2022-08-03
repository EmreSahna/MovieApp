namespace MovieApp.Dto
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class CreateCustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<int> Purchased { get; set; }
        public List<int> Favorite { get; set; }
    }
    public class CustomerViewWithDetailsDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Purchased { get; set; }
        public List<string> Favorite { get; set; }

    }
    public class CustomerPurchaseMovie
    {
        public List<int> Purchased { get; set; }
    }

    public class CustomerLoginDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
