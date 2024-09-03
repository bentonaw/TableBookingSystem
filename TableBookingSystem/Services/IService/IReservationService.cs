using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;
using TableBookingSystem.Models.ViewModels;

namespace TableBookingSystem.Services.IService
{
	public interface IReservationService
	{
		Task<IEnumerable<ReservationViewModel>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
		Task<IEnumerable<ReservationViewModel>> GetReservationsByCustomerLastNameAsync(string lastName);
		Task<ReservationViewModel> GetReservationByIdAsync(int reservationId);
		Task AddReservationAsync(ReservationDTO reservationDTO);
		Task UpdateReservationAsync(int reservationId, ReservationDTO reservationDTO);
		Task DeleteReservationAsync(int reservationId);
	}
}
