using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Core.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
