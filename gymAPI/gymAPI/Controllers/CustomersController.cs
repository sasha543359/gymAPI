using Microsoft.AspNetCore.Mvc;
using gymAPI.Services;
using GymDbContext_.Data.Models;

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
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public IActionResult CreateCustomer(Customer customerDto)
        {
            var customer = _customerService.CreateCustomer(customerDto);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }
            var customer = _customerService.UpdateCustomer(id, customerDto);
            if (customer == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.DeleteCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
