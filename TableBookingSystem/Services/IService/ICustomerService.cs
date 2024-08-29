using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Services.IService
{
	public interface ICustomerService
	{
		Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
		Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
		Task AddCustomersAsync(CustomerDTO customer);
		Task UpdateCustomerAsync(CustomerDTO customer);
		Task DeleteCustomerAsync(int customerId);
	}
}
