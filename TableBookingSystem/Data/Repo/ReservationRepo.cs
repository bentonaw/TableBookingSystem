using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo
{
	public class ReservationRepo : IReservationRepo
	{
		private readonly TableBookingSystemContext _context;
        public ReservationRepo(TableBookingSystemContext context)
        {
			_context = context;
        }
        public async Task AddReservationAsync(Reservation reservation)
		{
			await _context.Reservations.AddAsync(reservation);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteReservationAsync(int reservationId)
		{
			var reservation = await _context.Reservations.FindAsync(reservationId);
			if (reservation != null)
			{
				_context.Reservations.Remove(reservation);
			}
			await _context.SaveChangesAsync();
		}

		public async Task<Reservation> GetReservationByIdAsync(int reservationId)
		{
			var reservation = await _context.Reservations
				.Include(r => r.Customer)
				.Include(r => r.Timeslot)
				.FirstOrDefaultAsync(r => r.ReservationId == reservationId);
			return reservation;
		}

		public async Task<IEnumerable<Reservation>> GetReservationsByCustomerLastNameAsync(string lastName)
		{
			var reservations = await _context.Reservations
				.Where(r => r.Customer.LastName.Contains(lastName))
				.Include(r => r.Customer)
				.Include(r => r.Timeslot)
				.ToListAsync();
			return reservations;
		}

		public async Task<IEnumerable<Reservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate)
		{
			var reservations = await _context.Reservations
				.Where(r => r.ReservationDate >= startDate && r.ReservationDate <= endDate)
				.ToListAsync();
			return reservations;
		}

        public async Task<IEnumerable<TimeSlot>> GetTimeSlotAsync()
        {
			var timeslots = await _context.TimeSlots
				.ToListAsync();
			return timeslots;
        }

        public async Task UpdateReservationAsync(Reservation reservation)
		{
			_context.Reservations.Update(reservation);
			await _context.SaveChangesAsync();
		}

        public async Task<IEnumerable<Reservation>> GetReservationsForTableAsync(int tableId, DateTime date, int timeslotId)
        {
            var tableReservations = await _context.Reservations
                .Where(tr => tr.TableId == tableId && tr.ReservationDate.Date == date.Date && tr.TimeSlotId == timeslotId)
                .ToListAsync();
			return tableReservations;
        }
    }
}
