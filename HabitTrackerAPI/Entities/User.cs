using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }



        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }

        public Address Address { get; set; }
        public Guid AddressId { get; set; }

        public List<Target> Targets { get; set; } = new List<Target>();
    }
}
