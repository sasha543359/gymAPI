using GymDbContext_.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GymDbContext_.Data
{
    internal class GymDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSubscription> CustomersSubscriptions { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public GymDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1MGIDT7;Initial Catalog=Users;Integrated Security=True");
        }

    }
}
