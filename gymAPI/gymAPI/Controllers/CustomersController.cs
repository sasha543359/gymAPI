using GymDbContext_.Data.Models;
using GymDbContext_.Data.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return await _customerService.GetAllCustomers();
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var result = await _customerService.GetCustomerById(id);
            if (result == null)
                return NotFound("Custoemr with this Id doesn't exist");
            return Ok(result);
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Customer customer)
        {
            var result = await _customerService.CreateCustomer(customer);
            return Ok(result);
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer([FromBody] Customer customer, int id)
        {


            var result = await _customerService.UpdateCustomer(customer, id);

            return Ok(result);
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            if (result == null)
                return NotFound("Custoemr with this Id doesn't exist");
            return Ok(result);
        }
    }
}
