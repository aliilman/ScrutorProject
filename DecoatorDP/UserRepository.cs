using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrutorProject.UserServicve
{
    public class UserRepository : IRepository<User>
    {
        private readonly List<User> _users = new()
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            },
            new User
            {
                Id = 2,
                FirstName = "Janine",   
                LastName = "Doe"
            }
        };

        public IEnumerable<User> Get()
        {
            return _users;
        }

    }
}