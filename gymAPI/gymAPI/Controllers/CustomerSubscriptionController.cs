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

        public async Task<ActionResult<List<CustomerSubscription>>> GetSubscriptions()
        {
            try
            {
                return Ok(await _customerSubsriptionService.GetEntities());
            }
            catch (Exception ex)
            {
                Log.Error($"Get subscriptions has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }

        }

        // GET: api/customersubscription/id

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSubscription>> GetById(int id)
        {
            try
            {
                return Ok(await _customerSubsriptionService.GetEntity(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Get subscription by id has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }
        }


        // POST: api/customersubscription

        [HttpPost]

        public async Task<ActionResult<CustomerSubscription>> Post([FromBody] CustomerSubscription customerSubscription)
        {
            try
            {
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
        public async Task<ActionResult<CustomerSubscription>> Update(CustomerSubscription customerSubscription, int id)
        {
            try
            {
                return Ok(await _customerSubsriptionService.UpdateEntity(customerSubscription, id));
            }
            catch (Exception ex)
            {
                Log.Error($"Update subscription has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }
        }

        // DELETE: api/customersubscription/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerSubscription>> Delete(int id)
        {
            try
            {
                await _customerSubsriptionService.DeleteEntity(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"Delete subscription has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }
        }


    }
}
