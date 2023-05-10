using API;
using Microsoft.EntityFrameworkCore;

namespace GymDbContext_.Data.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        public readonly GymDbContext _context;

        public CustomerService(GymDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> CreateCustomer(Customer customer)
        {

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return _context.Customers.ToList();
        }

        public async Task<List<Customer>?> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return null;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return _context.Customers.ToList();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return null;

            return customer;
        }

        public async Task<List<Customer>?> UpdateCustomer(Customer customer, int id)
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

            return await _context.Customers.ToListAsync();


        }
    }
}
