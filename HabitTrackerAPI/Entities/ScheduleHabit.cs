namespace HabitTrackerAPI.Entities
{
    public class ScheduleHabit
    {
        public DateTime CreateDate { get; set; }

        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }

        public Habit Habit { get; set; }
        public int HabitId { get; set;}

    }
}
