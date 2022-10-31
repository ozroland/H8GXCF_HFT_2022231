using H8GXCF_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Logic.Interfaces
{
    public interface IMemberLogic
    {
        void Create(Member member);
        void Delete(int id);
        IEnumerable<Member> ReadAll();
        Member Read(int id);
        void Update(Member member);
    }
}
