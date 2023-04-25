using GymDbContext_.Data.Models;

namespace gymAPI.Services
{
    public class CustomerSubscriptionService : ICustomerSubscriptionService
    {
        private List<CustomerSubscription> _customerSubscriptions;

        public CustomerSubscriptionService()
        {
            _customerSubscriptions = new List<CustomerSubscription>();
        }

        public CustomerSubscription GetById(int id)
        {
            return _customerSubscriptions.Find(cs => cs.Id == id);
        }

        public CustomerSubscription Create(CustomerSubscription customerSubscription)
        {
            _customerSubscriptions.Add(customerSubscription);
            return customerSubscription;
        }

        public void Update(int id, CustomerSubscription customerSubscription)
        {
            CustomerSubscription existingCustomerSubscription = _customerSubscriptions.Find(cs => cs.Id == id);
            if (existingCustomerSubscription != null)
            {
                existingCustomerSubscription.Subscription = customerSubscription.Subscription;
                existingCustomerSubscription.Price = customerSubscription.Price;
                existingCustomerSubscription.PurschaseDay = customerSubscription.PurschaseDay;
                existingCustomerSubscription.ExpirationDay = customerSubscription.ExpirationDay;
            }
        }

        public void Delete(int id)
        {
            CustomerSubscription customerSubscriptionToRemove = _customerSubscriptions.Find(cs => cs.Id == id);
            if (customerSubscriptionToRemove != null)
            {
                _customerSubscriptions.Remove(customerSubscriptionToRemove);
            }
        }
    }
}
