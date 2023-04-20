using gymAPI.Models;

namespace gymAPI.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        Customer CreateCustomer(Customer customerDto);
        Customer UpdateCustomer(int id, Customer customerDto);
        Customer DeleteCustomer(int id);
    }
}
