using HabitTrackerAPI.Entities;
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
    }
}
