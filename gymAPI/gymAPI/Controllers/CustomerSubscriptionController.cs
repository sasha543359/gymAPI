using GymDbContext_.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSubscriptionController : ControllerBase
    {
        private readonly API.GymDbContext _gymDbContext;

        public CustomerSubscriptionController(API.GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        // GET api/customersubscriptions/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSubscription>> GetById(int id)
        {
            var customersubscription = await _gymDbContext.CustomersSubscriptions.FindAsync(id);
            return customersubscription;
        }

        // POST api/customersubscriptions
        [HttpPost]
        public async Task<ActionResult> Create(CustomerSubscription customersubscription)
        {
            await _gymDbContext.CustomersSubscriptions.AddAsync(customersubscription);
            await _gymDbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/customersubscriptions/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id)
        {
            var customersubscription = await _gymDbContext.CustomersSubscriptions.FindAsync(id);
            _gymDbContext.CustomersSubscriptions.Update(customersubscription);
            await _gymDbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/customersubscriptions/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customersubscription = await _gymDbContext.CustomersSubscriptions.FindAsync(id);
            _gymDbContext.CustomersSubscriptions.Remove(customersubscription);
            return Ok();
        }
    }
}
