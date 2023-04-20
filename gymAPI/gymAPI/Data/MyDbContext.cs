using gymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace gymAPI.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }                    
        public DbSet<Customer> Customers { get; set; }                 
        public DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }  

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
