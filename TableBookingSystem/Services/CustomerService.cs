﻿using AutoMapper;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
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
        public async Task AddCustomersAsync(CreateCustomerDTO customer)
		{
			var newCustomer = _mapper.Map<Customer>(customer);
			await _customerRepo.AddCustomersAsync(newCustomer);
		}

		public async Task DeleteCustomerAsync(int customerId)
		{
			var customer = await _customerRepo.GetCustomerByIdAsync(customerId);
			if (customer != null)
			{
				await _customerRepo.DeleteCustomerAsync(customerId);
			}
		}
		public async Task UpdateCustomerAsync(int customerId, CreateCustomerDTO customerDTO)
		{
			var customer = await _customerRepo.GetCustomerByIdAsync(customerId);

			// Updates only the properties that are provided
			if (!string.IsNullOrEmpty(customerDTO.FirstName))
			{
				customer.FirstName = customerDTO.FirstName;
			}
			if (!string.IsNullOrEmpty(customerDTO.LastName))
			{
				customer.LastName = customerDTO.LastName;
			}
			if (!string.IsNullOrEmpty(customerDTO.Email))
			{
				customer.Email = customerDTO.Email;
			}
			if (!string.IsNullOrEmpty(customerDTO.PhoneNumber))
			{
				customer.PhoneNumber = customerDTO.PhoneNumber;
			}
			await _customerRepo.UpdateCustomerAsync(customer);
		}

		public async Task<IEnumerable<GetCustomerDTO>> GetAllCustomersAsync()
		{
			var customersList = await _customerRepo.GetAllCustomersAsync();
			return _mapper.Map<IEnumerable<GetCustomerDTO>>(customersList);
		}

		public async Task<GetCustomerDTO> GetCustomerByIdAsync(int customerId)
		{
			var customer = await _customerRepo.GetCustomerByIdAsync(customerId);
			return customer != null ? _mapper.Map<GetCustomerDTO>(customer) : null;
		}

		
	}
}
