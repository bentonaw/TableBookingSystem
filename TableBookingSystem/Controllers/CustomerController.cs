using Microsoft.AspNetCore.Mvc;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;
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


		[HttpPost("createcustomer")]
		public async Task<ActionResult> CreateCustomer([FromBody] CustomerDTO customer)
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
		[HttpDelete("deletecustomer")]
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
		[HttpPut("updatecustomer")]
		public async Task<ActionResult> UpdateCustomerInfo([FromBody] CustomerDTO customer)
		{
			try
			{
				await _customerService.UpdateCustomerAsync(customer);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
		[HttpGet("getallcustomers")]
		public async Task<ActionResult<IEnumerable<CustomerViewModel>>> ViewAllCustomers(CustomerViewModel customer)
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
		[HttpGet("getcustomer")]
		public async Task<ActionResult> GetCustomerById(CustomerDTO customerDTO)
		{
			try
			{
				var customer = await _customerService.GetCustomerByIdAsync(customerDTO.CustomerId);
				if (customerDTO == null)
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
