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
    public class MembershipLogic : ILogic<Membership>
    {
        IMembershipRepository membershipRepository;
        public MembershipLogic(IMembershipRepository membershipRepository)
        {
            this.membershipRepository = membershipRepository;
        }
        public void Create(Membership item)
        {
            if (item.Name.Length < 2)
            {
                throw new ArgumentException("Membership name was too short...");
            }
            membershipRepository.Create(item);
        }

        public void Delete(int id)
        {
            var membership = membershipRepository.Read(id);
            if (membership == null)
            {
                throw new ArgumentException("Membership does not exists...");
            }
            membershipRepository.Delete(id);
        }

        public Membership Read(int id)
        {
            var membership = membershipRepository.Read(id);
            if (membership == null)
            {
                throw new ArgumentException("Membership does not exists...");
            }
            return membershipRepository.Read(id);
        }

        public IEnumerable<Membership> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Membership item)
        {
            if (item == null)
            {
                throw new ArgumentException("Membership does not exists...");
            }
            membershipRepository.Update(item);
        }
    }
}
