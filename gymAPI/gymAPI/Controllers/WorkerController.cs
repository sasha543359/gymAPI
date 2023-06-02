using GymDbContext_.Data.Models;
using GymDbContext_.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace gymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {

        private readonly IBaseRepository<Worker> _workerService;
        public WorkerController(IBaseRepository<Worker> workerService)
        {
            _workerService = workerService;
        }

        // GET: api/worker
        [HttpGet]
        public async Task<ActionResult<List<Worker>>> GetAllWorkers()
        {
            try
            {
                return await _workerService.GetEntities();
            }
            catch (Exception ex)
            {
                Log.Error($"Get workers has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }


        }

        // GET: api/worker/{id}
        [HttpGet("{id}")]

        public async Task<ActionResult<Worker>> GetWorkerById(int id)
        {
            try
            {
                var worker = await _workerService.GetEntity(id);

                if (worker == null)
                    return NotFound("Worker with this ID doesn't exist");

                return Ok(worker);
            }
            catch (Exception ex)
            {
                Log.Error($"Get worker by id has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }


        }

        // PUT: api/worker/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Worker>> UpdateWorkerById([FromBody] Worker worker, int id)
        {
            try
            {
                var wrker = await _workerService.UpdateEntity(worker, id);

                if (wrker == null)
                    return NotFound("Worker wasn't updated because worker with this ID does't exist");
                return Ok(wrker);
            }
            catch (Exception ex)
            {
                Log.Error($"Update worker has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }
        }


        // POST: api/worker
        [HttpPost]
        public async Task<ActionResult<Worker>> CreateWorker([FromBody] Worker worker)
        {

            try
            {
                var wrker = await _workerService.CreateEntity(worker);
                return Ok(wrker);
            }
            catch (Exception ex)
            {
                Log.Error($"Create worker has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }

        }

        // DELETE: api/worker/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> DeleteWorkerById(int id)
        {
            try
            {
                await _workerService.DeleteEntity(id);

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"Delete worker has failed \n {ex.Message}");
                return Problem(statusCode: 500, detail: ex.Message);

            }

        }
    }
}
