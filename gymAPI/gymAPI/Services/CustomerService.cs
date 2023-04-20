using gymAPI.Models;

namespace gymAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers;

        public CustomerService()
        {
            // Инициализация списка клиентов
            _customers = new List<Customer>();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            // Вернуть всех клиентов
            return _customers;
        }

        public Customer GetCustomerById(int id)
        {
            // Найти клиента по ID
            return _customers.Find(c => c.Id == id);
        }

        public Customer CreateCustomer(Customer customerDto)
        {
            // Создать нового клиента
            var newCustomer = new Customer
            {
                Id = GetNextId(),
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                // Дополнительные поля и логика
            };
            _customers.Add(newCustomer);
            return newCustomer;
        }

        public Customer UpdateCustomer(int id, Customer customerDto)
        {
            // Обновить информацию о клиенте по ID
            var existingCustomer = _customers.Find(c => c.Id == id);
            if (existingCustomer == null)
            {
                return null; // Или бросить исключение, если требуется
            }
            existingCustomer.FirstName = customerDto.FirstName;
            existingCustomer.LastName = customerDto.LastName;
            // Дополнительные поля и логика
            return existingCustomer;
        }

        public Customer DeleteCustomer(int id)
        {
            // Удалить клиента по ID
            var existingCustomer = _customers.Find(c => c.Id == id);
            if (existingCustomer == null)
            {
                return null; // Или бросить исключение, если требуется
            }
            _customers.Remove(existingCustomer);
            return existingCustomer;
        }

        private int GetNextId()
        {
            // Логика для генерации следующего ID
            // Может быть реализована на основе текущего состояния списка клиентов или других требований проекта
            // В данном примере просто генерируется уникальное положительное целое число
            int nextId = 1;
            if (_customers.Count > 0)
            {
                nextId = _customers.Max(c => c.Id) + 1;
            }
            return nextId;
        }
    }
}

