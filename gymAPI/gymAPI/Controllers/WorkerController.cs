using GymDbContext_.Data.Models;
using GymDbContext_.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace gymAPI.Controllers;

[Authorize]
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Worker>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Worker>>> GetAllWorkers()
    {
        try
        {
            var woreks = await _workerService.GetEntities();
            if (woreks == null) return NotFound();
            return Ok(woreks);
        }
        catch (Exception ex)
        {
            Log.Error($"Get workers has failed \n {ex.Message}");
            return Problem(statusCode: 500, detail: ex.Message);
        }
    }

    // GET: api/worker/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Worker))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Worker>> GetWorkerById(int id)
    {
        try
        {
            var worker = await _workerService.GetEntity(id);

            if (worker == null)
                return NotFound();

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
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Worker))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Worker>> UpdateWorkerById([FromBody] Worker worker, int id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var wrker = await _workerService.UpdateEntity(worker, id);

            if (wrker == null)
                return NotFound("Worker wasn't updated because worker with this ID does't exist");
            return Accepted(wrker);
        }
        catch (Exception ex)
        {
            Log.Error($"Update worker has failed \n {ex.Message}");
            return Problem(statusCode: 500, detail: ex.Message);

        }
    }

    // POST: api/worker
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Worker))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Worker>> CreateWorker([FromBody] Worker worker)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteWorkerById(int id)
    {
        try
        {
            await _workerService.DeleteEntity(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            Log.Error($"Delete worker has failed \n {ex.Message}");
            return Problem(statusCode: 500, detail: ex.Message);
        }
    }
}
