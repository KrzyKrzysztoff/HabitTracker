namespace HabitTrackerAPI.Interfaces
{
    public interface IAccountService
    {
        string Create(string username, string password, string confirmPassword);
    }
}
