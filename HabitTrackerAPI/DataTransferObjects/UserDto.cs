namespace HabitTrackerAPI.DataTransferObjects
{
    public class UserDto
    {
        public string EmailAdress { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
