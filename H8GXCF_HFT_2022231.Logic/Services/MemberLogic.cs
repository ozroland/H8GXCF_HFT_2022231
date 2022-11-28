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
    public class MemberLogic : IMemberLogic
    {
        IMemberRepository memberRepository;
        public MemberLogic(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        public void Create(Member member)
        {
            memberRepository.Create(member);
        }

        public void Delete(int id)
        {
            memberRepository.Delete(id);
        }

        public Member Read(int id)
        {
           return memberRepository.Read(id);
        }

        public IEnumerable<Member> ReadAll()
        {
            return memberRepository.ReadAll();
        }

        public void Update(Member member)
        {
           memberRepository.Update(member);
        }
        public double AVGAge()
        {
            return memberRepository.ReadAll().Average(t => t.Age);
        }
        public List<string> ActiveMembers()
        {
            return memberRepository.ReadAll()
                .Where(t => t.Membership.Active)
                .Select(t => t.Name).ToList();
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
    }
}