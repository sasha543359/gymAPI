using gymAPI.Services;
using GymDbContext_.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }


        // GET: api/worker/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var worker = _workerService.GetById(id);
            if (worker == null)
            {
                return NotFound();
            }
            return Ok(worker);
        }

        // POST: api/worker
        [HttpPost]
        public IActionResult Post([FromBody] Worker worker)
        {
            if (worker == null)
            {
                return BadRequest();
            }

            var createdWorker = _workerService.Create(worker);
            return CreatedAtAction(nameof(Get), new { id = createdWorker.Id }, createdWorker);
        }

        // PUT: api/worker/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Worker worker)
        {
            if (worker == null || id != worker.Id)
            {
                return BadRequest();
            }

            var existingWorker = _workerService.GetById(id);
            if (existingWorker == null)
            {
                return NotFound();
            }

            _workerService.Update(id, worker);
            return NoContent();
        }

        // DELETE: api/worker/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var worker = _workerService.GetById(id);
            if (worker == null)
            {
                return NotFound();
            }

            _workerService.Delete(id);
            return NoContent();
        }
    }
}
