using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface IReservationRepo
	{
		//Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime date);
		Task<IEnumerable<ReservationDTO>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
		Task<IEnumerable<ReservationDTO>> GetReservationsByCustomerLastNameAsync(string lastName);
		Task<ReservationDTO> GetReservationByIdAsync(int reservationId);
		Task AddReservationAsync(ReservationDTO reservationDTO);
		Task UpdateReservationAsync(ReservationDTO reservationDTO);
		Task DeleteReservationAsync(int reservationId);
	}
}
