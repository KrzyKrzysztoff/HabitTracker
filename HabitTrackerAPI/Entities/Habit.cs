using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Entities
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public int ActiveDaysStrike { get; set; }

        public Important Important { get; set; }
        public int ImportantId { get; set; }

        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
