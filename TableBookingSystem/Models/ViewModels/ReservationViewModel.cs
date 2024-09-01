namespace TableBookingSystem.Models.ViewModels
{
	public class ReservationViewModel
	{
		public int ReservationId { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public int TimeSlotId { get; set; }
		public TimeSlot Timeslot { get; set; }
		public ICollection<TableReservation> TableReservations { get; set; }
		public int NrOfSeats { get; set; }
		public DateTime ReservationDate { get; set; }
	}
}
