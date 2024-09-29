using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Services.IService
{
	public interface ITableReservationService
	{
        //Task<IEnumerable<ReservationVM>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
        //Task<IEnumerable<ReservationVM>> GetReservationsByCustomerLastNameAsync(string lastName);
        //Task<ReservationVM> GetReservationByIdAsync(int reservationId);
        //Task AddReservationAsync(CreateReservationDTO reservationDTO);
        //Task UpdateReservationAsync(int reservationId, CreateReservationDTO reservationDTO);
        //Task DeleteReservationAsync(int reservationId);

        //Task<IEnumerable<Table>> GetAvailableTablesForTimeSlot(int nrOfSeats);
        //Task AddTableReservation(int nrOfSeats);

        Task<IEnumerable<DateTime>> GetUnavailableDates(int nrOfSeats); // show *dates that doesnt have more available *seats than *nrOfSeats, to be used to be crossed out of calendar
        Task<IEnumerable<TimeSlot>> GetAvailableTimeSlotsForDate(int nrOfSeats, DateTime date); // get *timeslots on *date that have more available *seats than *nrOfSeats

        Task<IEnumerable<Table>> GetAvailableTablesForTimeSlot(int nrOfSeats, DateTime date, int timeslotId); // internal function, get first table that has available seats >= nrOfSeats, prio list see notion notes, to be used in conjucture with below

        Task CreateTableReservations(int nrOfSeats, DateTime date, int timeslotId); // internal function, get first table that has available seats >= nrOfSeats, prio list see notion notes,

    }
}
