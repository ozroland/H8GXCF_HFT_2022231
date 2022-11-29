using H8GXCF_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Logic.Interfaces
{
    public interface IMembershipLogic
    {
        void Create(Membership item);
        void Delete(int id);
        Membership Read(int id);
        IQueryable<Membership> ReadAll();
        void Update(Membership item);
    }
}
