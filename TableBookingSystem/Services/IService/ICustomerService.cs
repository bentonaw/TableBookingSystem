using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Services.IService
{
    public interface ICustomerService
	{
		Task<IEnumerable<GetCustomerDTO>> GetAllCustomersAsync();
		Task<GetCustomerDTO> GetCustomerByIdAsync(int customerId);
		Task AddCustomersAsync(CreateCustomerDTO customer);
		Task UpdateCustomerAsync(int customerId, CreateCustomerDTO customer);
		Task DeleteCustomerAsync(int customerId);
	}
}
