using GymDbContext_.Data.Enums;

namespace GymDbContext_.Data.Models
{
    public class Customer
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CustomerSubscription Subscription { get; set; }

        public Gender Gender { get; set; } = Gender.Male;

        public int Age { get; set; }

        public DateTime BirthDay { get; set; } = DateTime.Now;
    }
}
