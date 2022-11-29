using H8GXCF_HFT_2022231.Models;
using H8GXCF_HFT_2022231.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Logic.Interfaces
{
    public interface IMemberLogic
    {
        void Create(Member item);
        void Delete(int id);
        Member Read(int id);
        IQueryable<Member> ReadAll();
        void Update(Member item);
        public Dictionary<string, int> MaleFemaleCount();
        public Dictionary<string, int> InstructorClientCount();
        public Dictionary<string, int> MemberTypeCount();
        public Dictionary<string, double> AverageFeeByGender();
        public Dictionary<int, double> ActiveMembersAverageAgeAndCount();
    }
}
