using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;

namespace TableBookingSystem.Data.Repo
{
	public class CustomerRepo : ICustomerRepo
	{
		private readonly TableBookingSystemContext _context;
        public CustomerRepo(TableBookingSystemContext context)
        {
			_context = context;
        }

        public async Task AddCustomersAsync(Customer customer)
		{
			await _context.Customers.AddAsync(customer);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCustomerAsync(int customerId)
		{
			var customer = await _context.Customers.FindAsync(customerId);
			if (customer != null)
			{
				_context.Customers.Remove(customer);
			}
			await _context.SaveChangesAsync();
		}
		public async Task UpdateCustomerAsync(Customer customer)
		{
			_context.Customers.Update(customer);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
		{
			var CustomersList = await _context.Customers.ToListAsync();
			return CustomersList;
		}

		public async Task<Customer> GetCustomerByIdAsync(int CustomerId)
		{
			var customer = await _context.Customers.FindAsync(CustomerId);
			return customer;
		}
        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

    }
}
