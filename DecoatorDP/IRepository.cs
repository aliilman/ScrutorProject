using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrutorProject.UserServicve
{
    public interface IRepository<T> where  T :class
    {
        IEnumerable<T> Get();
    }
}