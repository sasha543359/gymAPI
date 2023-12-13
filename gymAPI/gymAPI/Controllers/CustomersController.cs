using GymDbContext_.Data.Models;
using GymDbContext_.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace gymAPI.Controllers;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Customer>>> GetCustomers()
    {
        try
        {
            var customer = await _customerService.GetEntities();
            if (customer == null) return NotFound();
            return Ok(customer);
        }
        catch (Exception ex)
        {
            Log.Error($"Get customers has failed \n {ex.Message}");
            return Problem(statusCode: 500, detail: ex.Message);
        }
    }

    // GET api/customers/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            Log.Error($"Get customer has failed \n {ex.Message}");
            return Problem(statusCode: 500, detail: ex.Message);
        }

    }

    // POST api/customers
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] Customer customer)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _customerService.CreateEntity(customer);
            if (result == null) return NoContent();
            return Ok(result);
        }
        catch (Exception ex)
        {

            Log.Error($"Create customer has failed \n {ex.Message}");
            return Problem(statusCode: 500, detail: ex.Message);
        }
    }

    // PUT api/customers/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Customer))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateCustomer([FromBody] Customer customer, int id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _customerService.UpdateEntity(customer, id);
            if (result == null) return NotFound();
            return Accepted(result);
        }
        catch (Exception ex)
        {
            Log.Error($"Update customer has failed \n {ex.Message}");
            return Problem(statusCode: 500, detail: ex.Message);
        }
    }

    // DELETE api/customers/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _customerService.DeleteEntity(id);
            return NoContent();
        }
        catch (Exception ex)
        {

            Log.Error($"Delete customer has failed \n {ex.Message}");
            return Problem(statusCode: 500, detail: ex.Message);
        }
    }
}
