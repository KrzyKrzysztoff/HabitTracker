namespace HabitTrackerAPI.Entities
{
    public class Important
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        public List<Habit> Habits { get; set; } = new List<Habit>();
        public List<Target> Targets { get; set; } = new List<Target>();
    }
}
