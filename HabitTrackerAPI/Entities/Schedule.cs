namespace HabitTrackerAPI.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }

        public List<Habit> Habits { get; set; } = new List<Habit>();

    }
}
