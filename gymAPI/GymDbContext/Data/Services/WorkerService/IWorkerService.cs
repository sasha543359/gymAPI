using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDbContext_.Data.Services.WorkerService
{
    public interface IWorkerService
    {
        Task<List<Worker>> GetAllWorkers();

        Task<Worker?> GetWorkerById(int id);

        Task<List<Worker>?> DeleteWorker(int id);

        Task<List<Worker>> CreateWorker(Worker worker);

        Task<Worker?> UpdateWorker(Worker worker, int id);



    }
}
