using GymDbContext_.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace API
{
    public class GymDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSubscription> CustomersSubscriptions { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public GymDbContext(DbContextOptions<GymDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var dataBaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dataBaseCreator != null)
                {
                    if (!dataBaseCreator.CanConnect()) dataBaseCreator.Create();
                    if (!dataBaseCreator.HasTables()) dataBaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
