using Microsoft.EntityFrameworkCore;
using TableBookingSystem.Data.Repo.IRepo;
using TableBookingSystem.Models;

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
			var reservation = await _context.Reservations.FindAsync(reservationId);
			return reservation;
		}

		public async Task<IEnumerable<Reservation>> GetReservationsByCustomerIdAsync(int customerId)
		{
			var reservations = await _context.Reservations
				.Where(r => r.Customer.CustomerId == customerId)
				.ToListAsync();
			return reservations;
		}

		//public Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime date)
		//{
		//	var reservations = await _context.Reservations.FindAsync(reservationId);
		//	return reservations;
		//}

		public async Task<IEnumerable<Reservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate)
		{
			var reservations = await _context.Reservations
				.Where(r => r.ReservationDate >= startDate && r.ReservationDate <= endDate)
				.ToListAsync();
			return reservations;
		}

		public async Task UpdateReservationAsync(Reservation reservation)
		{
			_context.Reservations.Update(reservation);
			await _context.SaveChangesAsync();
		}
	}
}
