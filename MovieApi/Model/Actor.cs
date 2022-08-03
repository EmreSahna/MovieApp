using FluentValidation;

namespace MovieApp.Model
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<MovieActor> StarredMovies { get; set; }
    }
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(x => x.ActorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(5);
        }
    }
}
