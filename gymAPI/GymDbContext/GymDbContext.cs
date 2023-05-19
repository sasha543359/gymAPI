using Microsoft.EntityFrameworkCore;

namespace API
{
    public class GymDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSubscription> CustomersSubscriptions { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public GymDbContext(DbContextOptions<GymDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=DESKTOP-7V70NQI\\SQLEXPRESS;Database=Gym;trusted_connection=True;TrustServerCertificate=True;";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("API"));
        }
    }
}
