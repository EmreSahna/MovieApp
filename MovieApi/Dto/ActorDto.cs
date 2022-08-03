using FluentValidation;

namespace MovieApp.Dto
{
    public class ActorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<int> MovieIds { get; set; }

    }
    public class ActorViewDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class ActorUpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class ActorViewWithMoviesDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Movies { get; set; }

    }
    
}
