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

        public async Task<IEnumerable<DateTime>> GetUnavailableDates(int nrOfSeats)
        {
            // Get all dates with reservations
            var reservationDates = await _context.Reservations
                .Select(r => r.ReservationDate)
                .Distinct()
                .ToListAsync();

            var unavailableDates = new List<DateTime>();

            foreach (var date in reservationDates)
            {
                // Check each timeslot for this date
                var timeslots = await _context.TimeSlots.ToListAsync();
                var isDateFullyBooked = true;

                foreach (var timeslot in timeslots)
                {
                    // Get available tables for this timeslot
                    var availableTables = await GetAvailableTablesForTimeSlot(nrOfSeats, date, timeslot.TimeSlotId);

                    if (availableTables.Any())
                    {
                        isDateFullyBooked = false;
                        break;
                    }
                }

                if (isDateFullyBooked)
                {
                    unavailableDates.Add(date);
                }
            }

            return unavailableDates;
        }

        public async Task<IEnumerable<Table>> GetAvailableTablesForTimeSlot(int nrOfSeats, DateTime date, int timeSlotId)
        {
            // Get all tables that have sufficient capacity
            var suitableTables = await _context.Tables
                .Where(t => t.Capacity >= nrOfSeats)
                .ToListAsync();

            var availableTables = new List<Table>();

            foreach (var table in suitableTables)
            {
                // Get existing reservations for this table, timeslot, and date
                var existingReservations = await _context.Reservations
                    .Where(r => r.TableId == table.TableId &&
                               r.TimeSlotId == timeSlotId &&
                               r.ReservationDate.Date == date.Date)
                    .SumAsync(r => r.NrOfSeats);

                // If communal table, check if there's enough remaining capacity
                if (table.IsCommunal)
                {
                    if (table.Capacity - existingReservations >= nrOfSeats)
                    {
                        availableTables.Add(table);
                    }
                }
                // For regular tables, check if the table is completely free
                else if (existingReservations == 0)
                {
                    availableTables.Add(table);
                }
            }

            return availableTables;
        }


        public async Task<IEnumerable<DateTime>> GetAllDatesWithReservationsFromToday()
        {
            var dates = await _context.Reservations
                .Where(rd => rd.ReservationDate >= DateTime.Today)
                .Select(d => d.ReservationDate)
                .ToListAsync();
            return dates;
        }


        public async Task DeleteTableReservations(int nrOfSeats, DateTime date, int timeslotId)
        {
            var reservationsToDelete = await _context.Reservations
                .Where(r => r.TimeSlotId == timeslotId &&
                           r.ReservationDate.Date == date.Date &&
                           r.NrOfSeats == nrOfSeats)
                .ToListAsync();

            _context.Reservations.RemoveRange(reservationsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task AddTableReservations(int nrOfSeats, DateTime date, int timeslotId)
        {
            var availableTables = await GetAvailableTablesForTimeSlot(nrOfSeats, date, timeslotId);
            if (!availableTables.Any())
            {
                throw new InvalidOperationException("No available tables for the specified criteria.");
            }

            // Select the most appropriate table (smallest available that fits the party)
            var selectedTable = availableTables
                .OrderBy(t => t.Capacity)
                .First();

            var reservation = new Reservation
            {
                TableId = selectedTable.TableId,
                TimeSlotId = timeslotId,
                ReservationDate = date,
                NrOfSeats = nrOfSeats
            };

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTableReservations(int nrOfSeats, DateTime date, int timeslotId)
        {
            // First check if there's an available table for the new requirements
            var availableTables = await GetAvailableTablesForTimeSlot(nrOfSeats, date, timeslotId);
            if (!availableTables.Any())
            {
                throw new InvalidOperationException("No available tables for the updated reservation.");
            }

            var existingReservation = await _context.Reservations
                .FirstOrDefaultAsync(r => r.TimeSlotId == timeslotId &&
                                        r.ReservationDate.Date == date.Date);

            if (existingReservation != null)
            {
                existingReservation.NrOfSeats = nrOfSeats;
                existingReservation.TableId = availableTables.First().TableId;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("No existing reservation found to update.");
            }
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

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _context.Tables
                .FirstOrDefaultAsync(t => t.TableId == tableId);
        }
    }
}
