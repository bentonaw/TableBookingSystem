using TableBookingSystem.Models;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface IReservationRepo
	{
		//Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime date);
		Task<IEnumerable<Reservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
		Task<IEnumerable<Reservation>> GetReservationsByCustomerIdAsync(int customerId);
		Task<Reservation> GetReservationByIdAsync(int reservationId);
		Task AddReservationAsync(Reservation reservation);
		Task UpdateReservationAsync(Reservation reservation);
		Task DeleteReservationAsync(int reservationId);
	}
}
