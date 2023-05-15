using GymDbContext_.Data.Models;
using GymDbContext_.Data.Services;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _customerSubsriptionService.GetEntities());
        }

        // GET: api/customersubscription/id

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSubscription>> GetById(int id)
        {
            return Ok(await _customerSubsriptionService.GetEntity(id));
        }


        // POST: api/customersubscription

        [HttpPost]

        public async Task<ActionResult<CustomerSubscription>> Post([FromBody] CustomerSubscription customerSubscription)
        {
            return Ok(await _customerSubsriptionService.CreateEntity(customerSubscription));
        }

        // PUT: api/customersubscription/id
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerSubscription>> Update(CustomerSubscription customerSubscription, int id)
        {
            return Ok(await _customerSubsriptionService.UpdateEntity(customerSubscription, id));
        }

        // DELETE: api/customersubscription/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerSubscription>> Delete(int id)
        {
            await _customerSubsriptionService.DeleteEntity(id);
            return Ok();
        }


    }
}
