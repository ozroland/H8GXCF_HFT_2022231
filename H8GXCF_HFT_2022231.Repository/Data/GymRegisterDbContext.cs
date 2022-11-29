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
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public GymRegisterDbContext()
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
                entity.HasOne(member => member.Membership)
                .WithMany(membership => membership.Members)
                .HasForeignKey(member => member.MembershipID)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasOne(member => member.Instructor)
                .WithMany(instructor => instructor.Members)
                .HasForeignKey(member => member.InstructorID)
                .OnDelete(DeleteBehavior.Cascade);
            });
            var pali = new Instructor()
            {
                Id = 1,
                Name = "Egyed Pál",
                Contact = "+36202634163",
                Address = "1034 Budapest Bécsi út 104-108",
                Email = "egyed.pal@gmail.com",
            };
            var peti = new Instructor()
            {
                Id = 2,
                Name = "Slezák Péter",
                Contact = "+36702321083",
                Address = "1034 Budapest Bécsi út 10",
                Email = "slezak.peter@gmail.com",
            };
            var robi = new Instructor()
            {
                Id = 3,
                Name = "Takács Róbert",
                Contact = "+36303210019",
                Address = "1034 Budapest Bécsi út 10",
                Email = "slezak.peter@gmail.com",
            };

            var roland = new Member()
            {
                Id = 1,
                Name = "Őz Roland",
                Contact = "+36806348231",
                Address = "1034 Budapest Bécsi út 104-108",
                Email = "oz.roland@gmail.com",
                Age = 20,
                Gender = Gender.Male,
            };
            var lipak = new Member()
            {
                Id = 2,
                Name = "Lipák Balázs",
                Contact = "+36901334513",
                Address = "1034 Budapest Görgely Artúr út 98",
                Email = "lipak.balazs@gmail.com",
                Age = 20,
                Gender = Gender.Male,
            };

            var diak = new Membership()
            {
                Id = 1,
                Name = "Diák",
                Active = true,
                JoiningDate = DateTime.Parse("2022.07.20"),
                SignupFee = 15000,
            };
            var teljes = new Membership()
            {
                Id = 2,
                Name = "Teljes",
                Active = false,
                JoiningDate = DateTime.Parse("2021.05.08"),
                EndingDate = DateTime.Parse("2022.09.17"),
                SignupFee = 20000,
            };

            modelBuilder.Entity<Member>().HasData(roland,lipak);
            modelBuilder.Entity<Membership>().HasData(diak, teljes);
            modelBuilder.Entity<Instructor>().HasData(pali,peti,robi);

        }
    }
}
