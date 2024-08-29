using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;

namespace TableBookingSystem.Services.IService
{
	public interface ICustomerService
	{
		Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync();
		Task<CustomerViewModel> GetCustomerByIdAsync(int customerId);
		Task AddCustomersAsync(CustomerDTO customer);
		Task UpdateCustomerAsync(CustomerDTO customer);
		Task DeleteCustomerAsync(int customerId);
	}
}
