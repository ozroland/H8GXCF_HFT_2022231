﻿using H8GXCF_HFT_2022231.Models;
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
    public class InstructorRepository : Repository<Instructor>, IRepository<Instructor>
    {
        public InstructorRepository(GymRegisterDbContext ctx) : base(ctx)
        {
        }
        public override Instructor Read(int id)
        {
            return ctx.Instructors.FirstOrDefault(x => x.Id == id);
        }
        public override void Update(Instructor item)
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
