using API;
using Microsoft.EntityFrameworkCore;

namespace GymDbContext_.Data.Services.CustomerSubscriptionService;

public class CustomerSubscriptionService : IBaseRepository<CustomerSubscription>
{
    private readonly GymDbContext gymDbContext;

    public CustomerSubscriptionService(GymDbContext gymDbContext)
    {
        this.gymDbContext = gymDbContext;
    }

    public async Task<List<CustomerSubscription>> GetEntities()
    {
        return await gymDbContext.CustomersSubscriptions.ToListAsync();
    }

    public async Task<CustomerSubscription> GetEntity(int id)
    {
        var customerstSubscription = await gymDbContext.CustomersSubscriptions.FindAsync(id);
        if (customerstSubscription == null) return null;
        return customerstSubscription;
    }

    public async Task<CustomerSubscription> UpdateEntity(CustomerSubscription customerSubscription, int id)
    {
        var customerstsubscription = await gymDbContext.CustomersSubscriptions.FindAsync(id);
        if (customerstsubscription == null) return null;

        customerstsubscription.Subscription = customerSubscription.Subscription;
        customerstsubscription.Price = customerSubscription.Price;
        customerstsubscription.PurschaseDay = customerSubscription.PurschaseDay;
        customerstsubscription.ExpirationDay = customerSubscription.ExpirationDay;

        gymDbContext.CustomersSubscriptions.Update(customerstsubscription);

        await gymDbContext.SaveChangesAsync();

        return customerstsubscription;

    }

    public async Task DeleteEntity(int id)
    {
        var customersubscription = await gymDbContext.CustomersSubscriptions.FindAsync(id);
        if (customersubscription != null)
            gymDbContext.Remove(customersubscription);
        await gymDbContext.SaveChangesAsync();




    }

    public async Task<CustomerSubscription> CreateEntity(CustomerSubscription customerSubscription)
    {
        await gymDbContext.AddAsync(customerSubscription);
        await gymDbContext.SaveChangesAsync();
        return customerSubscription;
    }

}
