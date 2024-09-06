using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface IReservationRepo
	{
		Task<IEnumerable<Reservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
		Task<IEnumerable<Reservation>> GetReservationsByCustomerLastNameAsync(string lastName);
		Task<Reservation> GetReservationByIdAsync(int reservationId);
		Task AddReservationAsync(Reservation reservation);
		Task UpdateReservationAsync(Reservation reservation);
		Task DeleteReservationAsync(int reservationId);
	}
}
