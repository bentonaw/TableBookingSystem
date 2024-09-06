using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;

namespace TableBookingSystem.Services.IService
{
	public interface IReservationService
	{
		Task<IEnumerable<ReservationVM>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
		Task<IEnumerable<ReservationVM>> GetReservationsByCustomerLastNameAsync(string lastName);
		Task<ReservationVM> GetReservationByIdAsync(int reservationId);
		Task AddReservationAsync(CreateReservationDTO reservationDTO);
		Task UpdateReservationAsync(int reservationId, CreateReservationDTO reservationDTO);
		Task DeleteReservationAsync(int reservationId);
	}
}
