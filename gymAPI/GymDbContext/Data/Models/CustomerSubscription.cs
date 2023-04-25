using GymDbContext_.Data.Enums;

namespace GymDbContext_.Data.Models
{
    public class CustomerSubscription
    {
        public int Id { get; set; }
        public Subscription Subscription { get; set; }
        public int Price { get; set; }
        public DateTime PurschaseDay { get; set; } = DateTime.Now;
        public DateTime ExpirationDay { get; set; }

    }
}
