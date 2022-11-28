using H8GXCF_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Logic.Interfaces
{
    public interface ILogic<T>
    {
        void Create(T item);
        void Delete(int id);
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Update(T item);
    }
}
