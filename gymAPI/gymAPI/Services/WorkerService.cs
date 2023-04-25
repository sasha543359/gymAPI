namespace gymAPI.Services
{
    using GymDbContext_.Data.Models;
    using System;
    using System.Collections.Generic;

    public class WorkerService : IWorkerService
    {
        private List<Worker> _workers;

        public WorkerService()
        {
            _workers = new List<Worker>();
        }

        public Worker GetById(int id)
        {
            return _workers.Find(w => w.Id == id);
        }

        public Worker Create(Worker worker)
        {
            _workers.Add(worker);
            return worker;
        }

        public void Update(int id, Worker worker)
        {
            Worker existingWorker = _workers.Find(w => w.Id == id);
            if (existingWorker != null)
            {
                existingWorker.FirstName = worker.FirstName;
                existingWorker.LastName = worker.LastName;
                existingWorker.Position = worker.Position;
                existingWorker.Email = worker.Email;
                existingWorker.PhoneNumber = worker.PhoneNumber;
                existingWorker.Salary = worker.Salary;
            }
        }

        public void Delete(int id)
        {
            Worker workerToRemove = _workers.Find(w => w.Id == id);
            if (workerToRemove != null)
            {
                _workers.Remove(workerToRemove);
            }
        }
    }

}
