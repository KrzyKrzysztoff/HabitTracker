using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Entities
{
    public class Habit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public ImportantLevel ImportantLevel { get; set; }
        public bool IsActive { get; set; }
        public int ActiveDaysStrike{ get; set; }
    }

    public enum ImportantLevel
    {
        None,
        Low,
        Medium,
        Hight
    }
}
