using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface ICustomerRepo
	{
		Task<IEnumerable<Customer>> GetAllCustomersAsync();
		Task<Customer> GetCustomerByIdAsync(int CustomerId);
		Task AddCustomersAsync(Customer customer);
		Task UpdateCustomerAsync(Customer customer);
		Task DeleteCustomerAsync(int customerId);
	}
}
