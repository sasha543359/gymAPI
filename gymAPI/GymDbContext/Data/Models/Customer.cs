using GymDbContext_.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymDbContext_.Data.Models
{
    [Table("customer", Schema = "dbo")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public int Id { get; set; }
        [Column("customer_fname")]
        public string FirstName { get; set; }
        [Column("customer_lname")]
        public string LastName { get; set; }
        [Column("customer_subscription")]
        public CustomerSubscription Subscription { get; set; }
        [Column("customer_gender")]
        public Gender Gender { get; set; } = Gender.Male;
        [Column("customer_age")]
        public int Age { get; set; }
        [Column("customer_bday")]
        public DateTime BirthDay { get; set; } = DateTime.Now;
    }
}
