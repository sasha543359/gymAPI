using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API
{
    public class GymDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSubscription> CustomersSubscriptions { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public GymDbContext(DbContextOptions<GymDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connectionString = _configuration.GetValue<string>("ConnectionStrings:myDb2");
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("API"));
            
        }
    }
}
