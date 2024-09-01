using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableBookingSystem.Models
{
	public class Reservation
	{
        [Key]
        public int ReservationId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		[ForeignKey("TimeSlot")]
        public int TimeSlotId { get; set; }
		public TimeSlot Timeslot { get; set; }
        [ForeignKey("TableReservation")]
		public ICollection<TableReservation> TableReservations { get; set; }
		[Required]
        public int NrOfSeats { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        
    }
}
