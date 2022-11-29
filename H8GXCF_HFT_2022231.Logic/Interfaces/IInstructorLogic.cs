using H8GXCF_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Logic.Interfaces
{
    public interface IInstructorLogic
    {
        void Create(Instructor item);
        void Delete(int id);
        Instructor Read(int id);
        IQueryable<Instructor> ReadAll();
        void Update(Instructor item);
    }
}
