using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaProce.Repos
{
    internal interface IRepo<T>
    {
        List<T> GetAll();
        bool Create(T entity);
    }
}
