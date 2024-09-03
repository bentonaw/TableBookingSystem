using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface ICustomerRepo
	{
		Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
		Task<CustomerDTO> GetCustomerByIdAsync(int CustomerId);
		Task AddCustomersAsync(Customer customer);
		Task UpdateCustomerAsync(Customer customer);
		Task DeleteCustomerAsync(int customerId);
	}
}
