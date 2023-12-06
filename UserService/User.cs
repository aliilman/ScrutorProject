using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrutorProject.UserServicve
{
    public class User
    {
        public required int Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
    }
}