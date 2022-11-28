using H8GXCF_HFT_2022231.Logic.Interfaces;
using H8GXCF_HFT_2022231.Models;
using H8GXCF_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Logic.Services
{
    public class MemberLogic : ILogic<Member>
    {
        IMemberRepository memberRepository;
        public MemberLogic(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        public void Create(Member item)
        {
            if (item.Name.Length < 3)
            {
                throw new ArgumentException("Member name was too short...");    
            }
            memberRepository.Create(item);
        }

        public void Delete(int id)
        {
            var member = memberRepository.Read(id);
            if (member == null)
            {
                throw new ArgumentException("Member does not exists...");
            }
            memberRepository.Delete(id);
        }

        public Member Read(int id)
        {
            var member = memberRepository.Read(id);
            if (member == null)
            {
                throw new ArgumentException("Member does not exists...");
            }
            return memberRepository.Read(id);
        }

        public IEnumerable<Member> ReadAll()
        {
            return memberRepository.ReadAll();
        }

        public void Update(Member item)
        {
            if (item == null)
            {
                throw new ArgumentException("member does not exists...");
            }
           memberRepository.Update(item);
        }
        public Dictionary<string, int> MaleFemaleCount()
        {
            var result = from x in memberRepository.ReadAll()
                         group x by x.Gender.ToString() into g
                         select new
                         {
                             g.Key,
                             Count = g.Count()
                         };
            return result.ToDictionary(x => x.Key, x => x.Count);
        }
        public Dictionary<string,int> InstructorClientCount ()
        {
            var result = from x in memberRepository.ReadAll()
                         group x by x.Instructor.Name into g
                         select new
                         {
                             g.Key,
                             Count = g.Count()
                         };
            return result.ToDictionary(x => x.Key, x => x.Count);
        }
        public Dictionary<string,int> MemberTypeCount()
        {
            var result =  from x in memberRepository.ReadAll()
                   group x by x.Membership.Name into g
                   select new 
                   {
                       g.Key,
                       Count = g.Count()
                   };
            return result.ToDictionary(x => x.Key, x => x.Count);
        }
        public Dictionary<string, double> AverageFeeByGender()
        {
            var result = from x in memberRepository.ReadAll()
                         group x by x.Gender.ToString() into g
                         select new
                         {
                             g.Key,
                             Avarage = g.Average(x => x.Membership.SignupFee)
                         };
            return result.ToDictionary(x => x.Key, x => x.Avarage);
        }
        public Dictionary<int, double> ActiveMembersAverageAgeAndCount()
        {
            var result = from x in memberRepository.ReadAll()
                         group x by x.Membership.Active into g where g.Key == true
                         select new
                         {
                             Count = g.Count(),
                             Average = g.Average(x => x.Age)
                         };
            return result.ToDictionary(x => x.Count, x => x.Average);
        }
        public double AverageMemberAge()
        {
            return memberRepository.ReadAll().Average(t => t.Age);
        }
        public int MemberCount()
        {
            return memberRepository.ReadAll().Count();
        }
    }
}