using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Manager.Inteface
{
    public interface IBaseManager<T>
    {
        List<T> GetAll();
        long Update(T Obj);
        long Add(T obj);
        T GetBy(long Id);

        void Delete(long Id);
    }
}
