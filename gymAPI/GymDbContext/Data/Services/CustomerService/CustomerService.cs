using API;
using Microsoft.EntityFrameworkCore;

namespace GymDbContext_.Data.Services.CustomerService
{
    public class CustomerService : IBaseRepository<Customer>
    {
        public readonly GymDbContext _context;

        public CustomerService(GymDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateEntity(Customer customer)
        {

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteEntity(int id)
        {
            var customer = await _context.Customers.FindAsync(id);


            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Customer>> GetEntities()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetEntity(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return null;

            return customer;
        }

        public async Task<Customer> UpdateEntity(Customer customer, int id)
        {
            var cst = await _context.Customers.FindAsync(id);
            if (cst == null)
                return null;

            cst.FirstName = customer.FirstName;
            cst.LastName = customer.LastName;
            cst.Subscription = customer.Subscription;
            cst.BirthDay = customer.BirthDay;
            cst.Gender = customer.Gender;
            cst.Age = customer.Age;

            await _context.SaveChangesAsync();

            return cst;


        }
    }
}
