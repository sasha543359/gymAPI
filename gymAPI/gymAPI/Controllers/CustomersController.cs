using Microsoft.AspNetCore.Mvc;
using GymDbContext_.Data.Models;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly API.GymDbContext _gymDbContext;

        public CustomersController(API.GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _gymDbContext.Customers;
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer = await _gymDbContext.Customers.FindAsync(id);
            return customer;
        }

        // POST api/customers
        [HttpPost]
       public async Task<ActionResult> Create(Customer customer)
        {
            await _gymDbContext.Customers.AddAsync(customer);
            await _gymDbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer([FromBody]Customer customer, int id)
        {
            customer = await _gymDbContext.Customers.FindAsync(id);
            _gymDbContext.Customers.Update(customer);
            await _gymDbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _gymDbContext.Customers.FindAsync(id);
            _gymDbContext.Customers.Remove(customer);
            return Ok();
        }
    }
}
