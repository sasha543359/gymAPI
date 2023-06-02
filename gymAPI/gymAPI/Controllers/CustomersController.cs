using GymDbContext_.Data.Models;
using GymDbContext_.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IBaseRepository<Customer> _customerService;

        public CustomersController(IBaseRepository<Customer> customerService)
        {
            _customerService = customerService;
        }

        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            try
            {
                return await _customerService.GetEntities();

            }
            catch(Exception ex)
            {
                Log.Error($"Get customers has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }
        }

        // GET api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            try
            {
                var result = await _customerService.GetEntity(id);
                if (result == null)
                    return NotFound("Custoemr with this Id doesn't exist");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"Get customers has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }
            
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Customer customer)
        {
            try
            {
                var result = await _customerService.CreateEntity(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {

                Log.Error($"Get customers has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer([FromBody] Customer customer, int id)
        {


            try
            {
                var result = await _customerService.UpdateEntity(customer, id);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Log.Error($"Get customers has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        // DELETE api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _customerService.DeleteEntity(id);
                return Ok();
            }
            catch (Exception ex)
            {

                Log.Error($"Get customers has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }
    }
}
