using H8GXCF_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Repository.Data
{
    public partial class GymRegisterDbContext : DbContext
    {
        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public GymRegisterDbContext()
        {
            this.Database.EnsureCreated();
        }
        public GymRegisterDbContext(DbContextOptions<GymRegisterDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("gymregister").UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasOne(member => member.Gym).WithMany().HasForeignKey(member => member.GymID).OnDelete(DeleteBehavior.ClientSetNull);
            });

            Gym arnold = new Gym() { Id = 1, Name = "ArnoldGym", Location = "Budapest 2.kerület" };
            Gym cutler = new Gym() { Id = 2, Name = "CutlerGym", Location = "Kecskemét" };

            Membership student = new Membership() { Id = 1, Category = Category.Student, HowLong = 10 };
            Membership normal = new Membership() { Id = 1, Category = Category.Normal, HowLong = 5 };

            Member roland = new Member() { Id = 1, Name = "Roland", Sex = Sex.Male, Age = 19, GymID = arnold.Id, MembershipID = student.Id};
            Member lili = new Member() { Id = 1, Name = "Lili", Sex = Sex.Female, Age = 22, GymID = cutler.Id, MembershipID = normal.Id };

            modelBuilder.Entity<Gym>().HasData(arnold, cutler);
            modelBuilder.Entity<Membership>().HasData(student, normal);
            modelBuilder.Entity<Member>().HasData(roland, lili);


        }
    }
}
