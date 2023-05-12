using API;
using Microsoft.EntityFrameworkCore;

namespace GymDbContext_.Data.Services.WorkerService
{
    public class WorkerService : IWorkerService
    {

        public readonly GymDbContext _context;

        public WorkerService(GymDbContext context)
        {
            _context = context;
        }

        public async Task<List<Worker>> CreateWorker(Worker worker)
        {
                 await _context.AddAsync(worker);
                 await _context.SaveChangesAsync();
                 var workers = await _context.Workers.ToListAsync();
                 await _context.SaveChangesAsync();
                 return workers;
        }

        public async Task<List<Worker>?> DeleteWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            if(worker == null)
                return null;
             _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            var workers = await _context.Workers.ToListAsync();
            return workers;

        }

        public async Task<List<Worker>> GetAllWorkers()
        {
           var workers = await _context.Workers.ToListAsync();
            return workers;
        }

        public async Task<Worker?> GetWorkerById(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
                return null;
            return worker;
        }

        public async Task<Worker?> UpdateWorker(Worker worker, int id)
        {
             var wrker = await GetWorkerById(id);
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
}
