using HabitTrackerAPI.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Database
{
    public class HabitTrackerDbContext : DbContext
    {
        public HabitTrackerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer("ConnectionString");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(eb =>
            {

                eb.HasOne(x => x.Address)
                .WithOne(a => a.User)
                .HasForeignKey<User>(f => f.AddressId); // wskazanie typu relacji, oraz kluczba obcego 1 - 1

                eb.HasOne(x=>x.Schedule)
                .WithOne(a => a.User)
                .HasForeignKey<User>(f => f.ScheduleId); 

                eb.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<Target>(eb =>
            {
                eb.HasOne(x => x.Important)
                .WithMany(x => x.Targets)
                .HasForeignKey(f => f.ImportantId); // wskazanie typu relacji, oraz kluczba obcego 1 -< *

                eb.HasMany(s => s.Users)
                .WithMany(s => s.Targets)
                .UsingEntity<TargetUser>( // ta metoda UsingEntity określa, że relacja wiele do wielu będzie używać trzeciej encji pośredniczącej

                    u => u.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId),

                    t => t.HasOne(t => t.Target)
                    .WithMany()
                    .HasForeignKey(t => t.TargetId),

                    ut =>
                    {
                        ut.HasKey(x => new { x.TargetId, x.UserId });
                        ut.Property(x => x.CrateDate).HasDefaultValue(DateTime.Now);
                    });
            });

            modelBuilder.Entity<Habit>(eb =>
            {
                eb.HasOne(x=>x.Important)
                .WithMany(a => a.Habits)
                .HasForeignKey(f => f.ImportantId); // wskazanie typu relacji, oraz kluczba obcego 1 -< *

                eb.HasMany(s => s.Schedules)
                .WithMany(h => h.Habits)
                .UsingEntity<ScheduleHabit>(  // wiele do wiele z tabelą łączącą która zawiera dodatkowe informację 
                    
                    s => s.HasOne(sh => sh.Schedule)
                    .WithMany()
                    .HasForeignKey(sh => sh.ScheduleId),

                     h => h.HasOne(sh => sh.Habit)
                    .WithMany()
                    .HasForeignKey(sh => sh.HabitId),


                    sh =>
                        {
                            sh.HasKey(x => new { x.HabitId, x.ScheduleId });
                            sh.Property(x=>x.CreateDate).HasDefaultValue(DateTime.Now);
                        }
                    );

            });

        }
    }
}
