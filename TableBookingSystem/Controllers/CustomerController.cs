using Microsoft.AspNetCore.Mvc;
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

		//Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
		//Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
		//Task AddCustomersAsync(CustomerDTO customer);
		//Task UpdateCustomerAsync(CustomerDTO customer);
		//Task DeleteCustomerAsync(int customerId);

		[HttpPost]
		public async Task<ActionResult> CreateCustomer([FromBody] CustomerDTO customer)
		{
			await _customerService.AddCustomersAsync(customer);
			return Ok();
		}
		[HttpDelete]
		[HttpPut]
		[HttpGet]
		[HttpGet]

	}
}
