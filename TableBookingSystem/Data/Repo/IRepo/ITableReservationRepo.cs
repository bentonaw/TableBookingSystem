using TableBookingSystem.Models;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface ITableReservationRepo
	{
		Task<IEnumerable<DateTime>> GetAllDatesWithReservationsFromToday(); 
		Task<IEnumerable<TimeSlot>> GetAllTimeslots(); 
		Task<IEnumerable<Table>> GetAllTables();

        Task<Table> GetTableByIdAsync(int tableId);
        //Task<IEnumerable<DateTime>> GetTablesWithReservations(int nrOfSeats); // show *dates that doesnt have more available *seats than *nrOfSeats, to be used to be crossed out of calendar
        //Task<IEnumerable<DateTime>> GetUnavailableDates(int nrOfSeats); // show *dates that doesnt have more available *seats than *nrOfSeats, to be used to be crossed out of calendar
        //Task<IEnumerable<TimeSlot>> GetAvailableTimeSlotsForDate(int nrOfSeats, DateTime date); // get *timeslots on *date that have more available *seats than *nrOfSeats

        //Task<IEnumerable<Table>> GetAvailableTablesForTimeSlot(int nrOfSeats, DateTime date, int timeslotId); // internal function, get first table that has available seats >= nrOfSeats, prio list see notion notes, to be used in conjucture with below

        Task DeleteTableReservations(int nrOfSeats, DateTime date, int timeslotId); // internal function, get first table that has available seats >= nrOfSeats, prio list see notion notes,
        Task AddTableReservations(int nrOfSeats, DateTime date, int timeslotId); // internal function, get first table that has available seats >= nrOfSeats, prio list see notion notes,
        Task UpdateTableReservations(int nrOfSeats, DateTime date, int timeslotId); // internal function, get first table that has available seats >= nrOfSeats, prio list see notion notes,
        //Task CreateTableReservations(int nrOfSeats, DateTime date, int timeslotId); // internal function, get first table that has available seats >= nrOfSeats, prio list see notion notes,
	}
}
