using H8GXCF_HFT_2022231.Models;
using H8GXCF_HFT_2022231.Repository.Data;
using H8GXCF_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected GymRegisterDbContext ctx;
        public Repository(GymRegisterDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public T Read(int id)
        {
            return ctx.Set<T>().FirstOrDefault(item => item.Id == id);
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public void Update(T item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
