using GymDbContext_.Data.Models;

namespace gymAPI.Services
{
    public interface IWorkerService
    {
        Worker GetById(int id);
        Worker Create(Worker worker);
        void Update(int id, Worker worker);
        void Delete(int id);
    }
}
