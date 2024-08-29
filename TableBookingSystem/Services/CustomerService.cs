using AutoMapper;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;
using TableBookingSystem.Services.IService;

namespace TableBookingSystem.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepo _customerRepo;
		private readonly IMapper _mapper;
        public CustomerService(ICustomerRepo customerRepo, IMapper mapper)
        {
			_customerRepo = customerRepo;
			_mapper = mapper;
        }
        public async Task AddCustomersAsync(CustomerDTO customer)
		{
			var newCustomer = _mapper.Map<Customer>(customer);
			await _customerRepo.AddCustomersAsync(newCustomer);
		}

		public async Task DeleteCustomerAsync(int customerId)
		{
			var customer = await _customerRepo.GetCustomerByIdAsync(customerId);
			if (customer != null)
			{
				_customerRepo.DeleteCustomerAsync(customerId);
			}
		}
		public async Task UpdateCustomerAsync(CustomerDTO customer)
		{
			var updatedCustomer = _mapper.Map<Customer>(customer);
			await _customerRepo.UpdateCustomerAsync(updatedCustomer);
		}

		public async Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync()
		{
			var customersList = await _customerRepo.GetAllCustomersAsync();
			return _mapper.Map<IEnumerable<CustomerViewModel>>(customersList);
		}

		public async Task<CustomerViewModel> GetCustomerByIdAsync(int customerId)
		{
			var customer = await _customerRepo.GetCustomerByIdAsync(customerId);
			return customer != null ? _mapper.Map<CustomerViewModel>(customer) : null;
		}

		
	}
}
