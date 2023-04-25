using gymAPI.Services;
using GymDbContext_.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSubscriptionController : ControllerBase
    {
        private readonly ICustomerSubscriptionService _customerSubscriptionService;

        public CustomerSubscriptionController(ICustomerSubscriptionService customerSubscriptionService)
        {
            _customerSubscriptionService = customerSubscriptionService;
        }

        // GET api/customersubscriptions/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Получение данных о CustomerSubscription из базы данных
            var customerSubscription = _customerSubscriptionService.GetById(id);

            // Возвращение CustomerSubscription в качестве DTO
            var customerSubscriptionDto = new
            {
                CustomerSubscriptionId = customerSubscription.Id,
                Subscription = customerSubscription.Subscription,
                Price = customerSubscription.Price,
                PurschaseDay = customerSubscription.PurschaseDay,
                ExpirationDay = customerSubscription.ExpirationDay
            };

            return Ok(customerSubscriptionDto);
        }

        // POST api/customersubscriptions
        [HttpPost]
        public IActionResult Post([FromBody] CustomerSubscription customerSubscription)
        {
            // Создание нового CustomerSubscription
            var createdCustomerSubscription = _customerSubscriptionService.Create(customerSubscription);

            // Возвращение созданного CustomerSubscription в качестве DTO
            var customerSubscriptionDto = new
            {
                CustomerSubscriptionId = createdCustomerSubscription.Id,
                Subscription = createdCustomerSubscription.Subscription,
                Price = createdCustomerSubscription.Price,
                PurschaseDay = createdCustomerSubscription.PurschaseDay,
                ExpirationDay = createdCustomerSubscription.ExpirationDay
            };

            return CreatedAtAction(nameof(Get), new { id = createdCustomerSubscription.Id }, customerSubscriptionDto);
        }

        // PUT api/customersubscriptions/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerSubscription customerSubscription)
        {
            // Обновление данных о CustomerSubscription
            _customerSubscriptionService.Update(id, customerSubscription);

            return NoContent();
        }

        // DELETE api/customersubscriptions/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Удаление CustomerSubscription
            _customerSubscriptionService.Delete(id);

            return NoContent();
        }
    }
}
