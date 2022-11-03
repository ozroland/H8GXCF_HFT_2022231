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
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<WorkoutPlan> WorkoutPlans { get; set; }
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

            modelBuilder.Entity<WorkoutPlan>(entity =>
            {
                entity.HasOne(workoutplan => workoutplan.Instructor)
                .WithMany(instructor => instructor.WorkoutPlans)
                .HasForeignKey(workoutplan => workoutplan.InstructorID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkoutPlan>(entity =>
            {
                entity.HasOne(workoutplan => workoutplan.Workout)
                .WithMany(workout => workout.WorkoutPlans)
                .HasForeignKey(workoutplan => workoutplan.WorkoutID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkoutPlan>(entity =>
            {
                entity.HasOne(workoutplan => workoutplan.Member)
                .WithMany(member => member.WorkoutPlans)
                .HasForeignKey(workoutplan => workoutplan.MemberID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });



        }
    }
}
