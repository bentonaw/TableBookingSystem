using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;

namespace TableBookingSystem.Data.Repo
{
    public class TableReservationRepo : ITableReservationRepo
    {
        private readonly TableBookingSystemContext _context;
        public TableReservationRepo(TableBookingSystemContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<DateTime>> GetUnavailableDates(int nrOfSeats)
        //{
        //    // Get all dates with reservations
        //    var reservationDates = await _context.Reservations
        //        .Select(r => r.ReservationDate)
        //        .Distinct()
        //        .ToListAsync();

        //    // Get all timeslots
        //    var timeSlots = await _context.TimeSlot
        //        .Select(ts => ts.TimeSlotId)
        //        .ToListAsync();

        //    // Get dates where all tables are booked for all timeslots
        //var fullyBookedDates = await _context.Reservations
        //        .GroupBy(r => r.ReservationDate)
        //        .Where(g => g.SelectMany(r => r.TableReservations).Count() == _context.Tables.Count() * timeSlots.Count)
        //        .Select(g => g.Key)
        //        .ToListAsync();

        //    // Get dates where no table has a capacity less than nrOfSeats
        //    var insufficientCapacityDates = await _context.Tables
        //        .Where(t => t.Capacity < nrOfSeats)
        //        .SelectMany(t => t.TableReservations)
        //        .Select(tr => tr.Reservation.ReservationDate)
        //        .Distinct()
        //        .ToListAsync();

        //    // Combine the results
        //    var unavailableDates = fullyBookedDates.Union(insufficientCapacityDates).Distinct();

        //    return unavailableDates;
        //}

        //      public async Task<IEnumerable<Table>> GetAvailableTablesForTimeSlot(int nrOfSeats, DateTime date, int timeSlotId)
        //{
        //          var reservedTableIds = await _context.TableReservations
        //              .Where(tr => tr.Reservation.ReservationDate == date && tr.Reservation.TimeSlotId == timeSlotId)
        //              .Select(tr => tr.TableId)
        //              .ToListAsync();

        //          var availableTables = await _context.Tables
        //              .Where(t => !reservedTableIds.Contains(t.TableId) && t.Capacity >= nrOfSeats)
        //              .ToListAsync();

        //          return availableTables;
        //      }


        public async Task<IEnumerable<DateTime>> GetAllDatesWithReservationsFromToday()
        {
            var dates = await _context.Reservations
                .Where(rd => rd.ReservationDate >= DateTime.Today)
                .Select(d => d.ReservationDate)
                .ToListAsync();
            return dates;
        }


        public Task DeleteTableReservations(int nrOfSeats, DateTime date, int timeslotId)
        {
            throw new NotImplementedException();
        }

        public Task AddTableReservations(int nrOfSeats, DateTime date, int timeslotId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTableReservations(int nrOfSeats, DateTime date, int timeslotId)
        {
            throw new NotImplementedException();
        }

        // can be extracted into seperate repo
        public async Task<IEnumerable<TimeSlot>> GetAllTimeslots()
        {
            var timeSlots = await _context.TimeSlots
                .ToListAsync();
            return timeSlots;
        }
        public async Task<IEnumerable<Table>> GetAllTables()
        {
            var tables = await _context.Tables
                .ToListAsync();
            return tables;
        }

        public Task<Table> GetTableByIdAsync(int tableId)
        {
            throw new NotImplementedException();
        }
    }
}
