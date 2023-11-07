namespace HabitTrackerAPI.Entities
{
    public class Target
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DestinationDate { get; set; }
        public DateTime StartDate{ get; set; }

        public Important Important { get; set; }
        public int ImportantId { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
