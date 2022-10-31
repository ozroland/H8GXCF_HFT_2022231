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
    }
}
