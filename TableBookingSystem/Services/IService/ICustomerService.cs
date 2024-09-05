using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;

namespace TableBookingSystem.Services.IService
{
	public interface ICustomerService
	{
		Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync();
		Task<CustomerViewModel> GetCustomerByIdAsync(int customerId);
		Task AddCustomersAsync(CreateCustomerDTO customer);
		Task UpdateCustomerAsync(int customerId, CreateCustomerDTO customer);
		Task DeleteCustomerAsync(int customerId);
	}
}
