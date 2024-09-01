using Microsoft.AspNetCore.Mvc;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;
using TableBookingSystem.Services;
using TableBookingSystem.Services.IService;

namespace TableBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationController : ControllerBase
	{

		private readonly IReservationService _reservationService;
		public ReservationController(IReservationService reservationService)
		{
			_reservationService = reservationService;
		}

		[HttpGet("date-range")]
		public async Task<ActionResult<IEnumerable<ReservationViewModel>>> GetReservationsByDateRange(DateTime startDate, DateTime endDate)
		{
			try
			{
				var reservations = await _reservationService.GetReservationsByDateRangeAsync(startDate, endDate);
				return Ok(reservations);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}

		}

		[HttpGet("customer/{customerId}")]
		public async Task<ActionResult<IEnumerable<ReservationViewModel>>> GetReservationsByCustomerId(int customerId)
		{
			try
			{
				var customer = await _reservationService.GetReservationsByCustomerIdAsync(customerId);
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

		[HttpGet("{reservationId}")]
		public async Task<ActionResult<ReservationViewModel>> GetReservationById(int reservationId)
		{
			try
			{
				var reservation = await _reservationService.GetReservationByIdAsync(reservationId);
				if (reservation == null)
				{
					return NotFound();
				}
				return Ok(reservation);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}

		}

		[HttpPost]
		public async Task<ActionResult> CreateReservation([FromBody] ReservationDTO reservationDTO)
		{
			try
			{
				await _reservationService.AddReservationAsync(reservationDTO);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpPatch("{reservationId}")]
		public async Task<ActionResult> UpdateReservation(int reservationId, [FromBody] ReservationDTO reservationDTO)
		{
			try
			{
				await _reservationService.UpdateReservationAsync(reservationId, reservationDTO);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpDelete("{reservationId}")]
		public async Task<ActionResult> DeleteReservation(int reservationId)
		{
			try
			{
				await _reservationService.DeleteReservationAsync(reservationId);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
	}
}
