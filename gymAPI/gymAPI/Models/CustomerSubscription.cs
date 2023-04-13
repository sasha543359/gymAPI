namespace gymAPI.Models
{
    public enum Subscription
    {
        Basic = 0 ,
        Silver = 10,
        Gold = 15
    }

    public class CustomerSubscription
    {
        
        public Subscription Subscription { get; set; }
        public int Price { get; set; }

        public DateTime PurschaseDay { get; set; } = DateTime.Now;

        public DateTime ExpirationDay { get; set; }

        public CustomerSubscription(Subscription subscription)
        {
            this.Subscription = subscription;
            this.Price = (int)subscription;
            PurschaseDay = DateTime.Now;
            ExpirationDay = Expiration(PurschaseDay);

        }

        private DateTime Expiration(DateTime PurschaseDay)
        {
            PurschaseDay = DateTime.Now;

            DateTime ExpirationDate;

            switch (Subscription)
            {
                    case Subscription.Basic:
                        return ExpirationDate = PurschaseDay.AddDays(7);

                    case Subscription.Silver:
                        return ExpirationDate = PurschaseDay.AddDays(30);

                    case Subscription.Gold:
                        return ExpirationDate = PurschaseDay.AddDays(180);
                    
                    default:
                        return DateTime.Now;  
            }
        }

    }
}
