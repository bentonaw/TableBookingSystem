﻿using TableBookingSystem.Models;
using TableBookingSystem.Models.DTOs;

namespace TableBookingSystem.Data.Repo.IRepo
{
	public interface IReservationRepo
	{
		Task<IEnumerable<Reservation>> GetReservationsByDateRangeAsync(DateTime startDate, DateTime endDate);
		Task<IEnumerable<Reservation>> GetReservationsByCustomerLastNameAsync(string lastName);
		Task<IEnumerable<TimeSlot>> GetTimeSlotAsync();
		Task<Reservation> GetReservationByIdAsync(int reservationId);
		Task AddReservationAsync(Reservation reservation);
		Task UpdateReservationAsync(Reservation reservation);
		Task DeleteReservationAsync(int reservationId);
        Task<IEnumerable<Reservation>> GetReservationsForTableAsync(int tableId, DateTime date, int timeslotId);
    }
}
