namespace gymAPI.Models
{
    public enum Gender
    {
        Male,
        Female,
        Transgender
    }

    public class Customer
    {

        // включая его имя, фамилию, дату рождения, пол и другую персональную информацию.
        public string FirstName { get; set; } 
        public string LastName { get; set; }

        public CustomerSubscription Subscription { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        public int Age { get; set; }
        public DateTime BirthDay { get; set; } = DateTime.Now;

        public Customer(string FirstName, string LastName, int Age, CustomerSubscription subscription)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            Subscription = subscription;
        }




    }
}
