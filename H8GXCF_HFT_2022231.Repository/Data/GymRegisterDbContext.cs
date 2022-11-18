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
                entity.HasOne(member => member.Membership)
                .WithMany(membership => membership.Members)
                .HasForeignKey(member => member.MembershipID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasOne(member => member.Instructor)
                .WithMany(instructor => instructor.Members)
                .HasForeignKey(member => member.InstructorID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            Instructor pali = new Instructor()
            {
                Id = 1,
                Name = "Egyed Pál",
                Contact = "+36702652863",
                Address = "1034 Budapest Bécsi út 104-108",
                Email = "egyed.pali@gmail.com",
            };
            Member roli = new Member() {
                Id = 1,
                Name = "Őz Roland",
                Contact = "+36306018905",
                Address = "1034 Budapest Bécsi út 104-108",
                Email = "ozroland46@gmail.com",
                Age = 20,
                Gender = Gender.Male,
                Membership = new Membership() {
                    Id = 1,
                    Name = "Diák",
                    Active = true,
                    JoiningDate = DateTime.Parse("2022.07.20"),
                    SignupFee = 15000,
                },
                MembershipID = 1,
                Instructor = pali,
                InstructorID = pali.Id,
            };
            Member balazs = new Member(){
                Id = 2,
                Name = "Lipák Balázs",
                Contact= "+36501345139",
                Address= "1034 Budapest Görgely Artúr út 98",
                Email= "lipak.bazsi@gmail.com",
                Age = 20,
                Gender= Gender.Male,
                Membership= new Membership() {
                    Id = 2,
                    Name = "Teljes",
                    Active= false,
                    JoiningDate = DateTime.Parse("2021.05.08"),
                    EndingDate = DateTime.Parse("2022.09.17"),
                    SignupFee = 20000,
                },
                MembershipID= 2,
                Instructor = pali,
                InstructorID = pali.Id,
            };

            modelBuilder.Entity<Member>().HasData(roli,pali);
            modelBuilder.Entity<Membership>().HasData(roli.Membership, balazs.Membership);
            modelBuilder.Entity<Instructor>().HasData(pali);

        }
    }
}
