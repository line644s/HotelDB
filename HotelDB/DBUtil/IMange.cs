using System.Collections.Generic;
using Modellib.Model;

namespace HotelDB.DBUtil
{
    public interface IMange<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        bool Post(T value);
        bool Put(int id, T value);
        bool Delete(int id);
    }
}