namespace MovieApp.Dto
{
    public class DirectorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class DirectorWithMoviesDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Movies { get; set; }
    }
    public class DirectorUpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
