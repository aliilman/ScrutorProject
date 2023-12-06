using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrutorProject.UserServicve
{
    public class UserService : IUserService
    {
        public User GetUser(int id)
        {
            return new User
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe"
            };
        }
    }
}