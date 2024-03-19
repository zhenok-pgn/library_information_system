using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public interface IRepository<T>
    {
        List<T> SelectAll();
        T SelectById(int id);
        int Insert(T record);
        int Update(T record);
        int DeleteById(int id);
    }
}
