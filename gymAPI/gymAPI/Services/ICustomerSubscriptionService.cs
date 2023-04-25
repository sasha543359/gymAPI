using GymDbContext_.Data.Models;

namespace gymAPI.Services
{
    public interface ICustomerSubscriptionService
    {
        CustomerSubscription GetById(int id);
        CustomerSubscription Create(CustomerSubscription customerSubscription);
        void Update(int id, CustomerSubscription customerSubscription);
        void Delete(int id);
    }
}
