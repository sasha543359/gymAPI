using GymDbContext_.Data.Models;
using GymDbContext_.Data.Services.WorkerService;
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

        // GET: api/worker
        [HttpGet]
        public async Task<ActionResult<List<Worker>>> GetAllWorkers()
        {
            return await _workerService.GetAllWorkers();


        }

        // GET: api/worker/{id}
        [HttpGet("{id}")]

        public async Task<ActionResult<Worker>> GetWorkerById(int id)
        {
            var worker = await _workerService.GetWorkerById(id);

            if (worker == null)
                return NotFound("Worker with this ID doesn't exist");

            return Ok(worker);


        }

        // PUT: api/worker/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Worker>> UpdateWorkerById([FromBody] Worker worker, int id)
        {
            var wrker = await _workerService.UpdateWorker(worker, id);

            if (wrker == null)
                return NotFound("Worker wasn't updated because worker with this ID does't exist");
            return Ok(wrker);
        }


        // POST: api/worker
        [HttpPost]
        public async Task<ActionResult<Worker>> CreateWorker([FromBody] Worker worker)
        {
            var wrker = await _workerService.CreateWorker(worker);
            return Ok(wrker);


        }

        // DELETE: api/worker/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> DeleteWorkerById(int id)
        {
            var wrker = await _workerService.DeleteWorker(id);
            if (wrker == null)
                return NotFound($"Worker with {id} ID wasnt deleted because cannot find worker with this ID");
            return Ok(wrker);

        }
    }
}
