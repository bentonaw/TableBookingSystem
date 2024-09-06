using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TableBookingSystem.Models.DTOs
{
	// Simplified CreateReservationDTO for easier use with frontend UI
	public class CreateReservationDTO
	{
		public int CustomerId { get; set; }
		//public Customer Customer { get; set; }

		public int TimeSlotId { get; set; }
		//public TimeSlot Timeslot { get; set; }
		////public ICollection<TableReservation> TableReservations { get; set; } 
		// will create automatic function that checks available tables
		public int NrOfSeats { get; set; }
		[DataType(DataType.Date)]
		public DateTime ReservationDate { get; set; }
	}
}
