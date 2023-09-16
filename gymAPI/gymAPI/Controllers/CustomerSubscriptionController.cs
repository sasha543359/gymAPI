using GymDbContext_.Data.Models;
using GymDbContext_.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSubscriptionController : ControllerBase
    {

        private readonly IBaseRepository<CustomerSubscription> _customerSubsriptionService;

        public CustomerSubscriptionController(IBaseRepository<CustomerSubscription> customerSubsriptionService)
        {
            _customerSubsriptionService = customerSubsriptionService;
        }

        // GET: api/customersubscription
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerSubscription>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CustomerSubscription>>> GetSubscriptions()
        {
            try
            {
                var subs = await _customerSubsriptionService.GetEntities();
                if (subs == null) return NotFound();

                return Ok(subs);
            }
            catch (Exception ex)
            {
                Log.Error($"Get subscriptions has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        // GET: api/customersubscription/id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerSubscription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerSubscription>> GetById(int id)
        {
            try
            {
                var sub = await _customerSubsriptionService.GetEntity(id);
                if (sub == null) return NotFound();
                return Ok(sub);
            }
            catch (Exception ex)
            {
                Log.Error($"Get subscription by id has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        // POST: api/customersubscription

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerSubscription))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerSubscription>> Post([FromBody] CustomerSubscription customerSubscription)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(await _customerSubsriptionService.CreateEntity(customerSubscription));
            }
            catch (Exception ex)
            {
                Log.Error($"Post subscription has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        // PUT: api/customersubscription/id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Worker))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerSubscription>> Update(CustomerSubscription customerSubscription, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var subs = await _customerSubsriptionService.UpdateEntity(customerSubscription, id);
                if (subs == null) return NotFound();
                return Accepted();
            }
            catch (Exception ex)
            {
                Log.Error($"Update subscription has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }
        }

        // DELETE: api/customersubscription/id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<CustomerSubscription>> Delete(int id)
        {
            try
            {
                await _customerSubsriptionService.DeleteEntity(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error($"Delete subscription has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }
        }
    }
}
