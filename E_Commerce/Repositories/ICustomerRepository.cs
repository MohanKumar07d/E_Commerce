using E_Commerce.Models;

namespace E_Commerce.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
