using API;
using Microsoft.EntityFrameworkCore;

namespace GymDbContext_.Data.Services.WorkerService;

public class WorkerService : IBaseRepository<Worker>
{

    public readonly GymDbContext _context;

    public WorkerService(GymDbContext context)
    {
        _context = context;
    }

    public async Task<Worker> CreateEntity(Worker worker)
    {
        await _context.AddAsync(worker);
        await _context.SaveChangesAsync();
        await _context.SaveChangesAsync();
        return worker;
    }

    public async Task DeleteEntity(int id)
    {
        var worker = await _context.Workers.FindAsync(id);

        _context.Workers.Remove(worker);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Worker>> GetEntities()
    {
        var workers = await _context.Workers.ToListAsync();
        return workers;
    }

    public async Task<Worker> GetEntity(int id)
    {
        var worker = await _context.Workers.FindAsync(id);
        if (worker == null)
            return null;
        return worker;
    }

    public async Task<Worker> UpdateEntity(Worker worker, int id)
    {
        var wrker = await GetEntity(id);
        if (wrker == null)
            return null;

        wrker.Salary = worker.Salary;
        wrker.PhoneNumber = worker.PhoneNumber;
        wrker.Email = worker.Email;
        wrker.Position = worker.Position;
        wrker.LastName = worker.LastName;
        wrker.FirstName = worker.FirstName;

        _context.Workers.Update(wrker);

        await _context.SaveChangesAsync();

        return wrker;
    }
}
