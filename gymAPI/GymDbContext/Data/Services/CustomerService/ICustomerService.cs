namespace GymDbContext_.Data.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Customer?> GetCustomerById(int id);

        Task<List<Customer>> CreateCustomer(Customer customer);

        Task<List<Customer>?> UpdateCustomer(Customer customer, int id);

        Task<List<Customer>?> DeleteCustomer(int id);
    }
}
