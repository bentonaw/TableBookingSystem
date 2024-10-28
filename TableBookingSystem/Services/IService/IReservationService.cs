using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Services.IService
{
    public interface IReservationService
	{
		Task<IEnumerable<GetReservationDTO>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
		Task<IEnumerable<GetReservationDTO>> GetReservationsByCustomerLastNameAsync(string lastName);
		Task<IEnumerable<GetTimeSlotDTO>> GetTimeSlotAsync(DateTime date, int partySize);
		Task<GetReservationDTO> GetReservationByIdAsync(int reservationId);
		Task AddReservationAsync(CreateReservationDTO reservationDTO);
		Task UpdateReservationAsync(int reservationId, CreateReservationDTO reservationDTO);
		Task DeleteReservationAsync(int reservationId);
	}
}
