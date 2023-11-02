namespace HabitTrackerAPI.Entities
{
    internal class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public List<Habit> Habits { get; set; }
    }
}
