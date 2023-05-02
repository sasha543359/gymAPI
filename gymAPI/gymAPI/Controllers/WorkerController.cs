using GymDbContext_.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly API.GymDbContext _gymDbContext;

        public WorkerController(API.GymDbContext gymDbContext)
        {
           _gymDbContext = gymDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Worker>> GetCustomers()
        {
            return _gymDbContext.Workers;
        }

        // GET: api/worker/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetById(int id)
        {
            var worker = await _gymDbContext.Workers.FindAsync(id);
            return worker;
        }

        // POST: api/worker
        [HttpPost]
        public async Task<ActionResult> Create(Worker worker)
        {
            await _gymDbContext.Workers.AddAsync(worker);
            await _gymDbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/worker/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id)
        {
            var worker = await _gymDbContext.Workers.FindAsync(id);
            _gymDbContext.Workers.Update(worker);
            await _gymDbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/worker/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var worker = await _gymDbContext.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _gymDbContext.Workers.Remove(worker);
            return NoContent();
        }
    }
}
