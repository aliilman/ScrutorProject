using ScrutorProject.UserServicve;

namespace ScrutorProject.UserService
{
    public class RepositoryLoggerDecorator<T> : IRepository<User>
    {
        private readonly IRepository<User> _decoratedRepository;
        public RepositoryLoggerDecorator(IRepository<User> decoratedRepository)
        {
            _decoratedRepository = decoratedRepository;
        }
        public IEnumerable<User> Get()
        {
            Console.WriteLine("The list of all users has been retrieved from the DB");

            return _decoratedRepository.Get();
        }
    }
}