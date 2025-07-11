using E_Commerce.Data;
using E_Commerce.Models;

namespace E_Commerce.Repositories
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly ECommerceContext eCommerceContext;

        public SqlCustomerRepository(ECommerceContext eCommerceContext)
        {
            this.eCommerceContext = eCommerceContext;
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await eCommerceContext.Customers.AddAsync(customer);
            await eCommerceContext.SaveChangesAsync();
            return customer;
        }
    }
}
