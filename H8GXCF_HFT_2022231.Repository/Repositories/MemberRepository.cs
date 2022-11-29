using H8GXCF_HFT_2022231.Models;
using H8GXCF_HFT_2022231.Repository.Data;
using H8GXCF_HFT_2022231.Repository.GenericRepository;
using H8GXCF_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Repository.Repositories
{
    public class MemberRepository : Repository<Member>, IRepository<Member>
    {
        public MemberRepository(GymRegisterDbContext ctx) : base(ctx)
        {
        }
        public override Member Read(int id)
        {
            return ctx.Members.FirstOrDefault(x => x.Id == id);
        }
        public override void Update(Member item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
