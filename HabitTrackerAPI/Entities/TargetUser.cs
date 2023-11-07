namespace HabitTrackerAPI.Entities
{
    public class TargetUser
    {
        public int Id { get; set; }
        public DateTime CrateDate { get; set; }

        public Target Target{ get; set; }
        public Guid TargetId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
