﻿using Microsoft.AspNetCore.Mvc;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Services.IService;

namespace TableBookingSystem.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		
		private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
			_customerService = customerService;
        }


		[HttpPost]
		public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerDTO customer)
		{
			try
			{
				await _customerService.AddCustomersAsync(customer);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpDelete("{customerId}")]
		public async Task<ActionResult> DeleteCustomer(int customerId)
		{
			try
			{
				await _customerService.DeleteCustomerAsync(customerId);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpPatch("{customerId}")]
		public async Task<ActionResult> UpdateCustomerInfo(int customerId, CreateCustomerDTO customer)
		{
			try
			{
				await _customerService.UpdateCustomerAsync(customerId, customer);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetCustomerDTO>>> ViewAllCustomers()
		{
			try
			{
				var listOfCustomers = await _customerService.GetAllCustomersAsync();
				return Ok(listOfCustomers);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpGet("{customerId}")]
		public async Task<ActionResult> GetCustomerById(int customerId)
		{
			try
			{
				var customer = await _customerService.GetCustomerByIdAsync(customerId);
				if (customer == null)
				{
					return NotFound();
				}
				return Ok(customer);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

	}
}
