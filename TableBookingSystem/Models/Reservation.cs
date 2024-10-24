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
		[ForeignKey("TimeSlot")]
        public int TimeSlotId { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }
		[Required]
        public int NrOfSeats { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }

        public Customer Customer { get; set; }
        public TimeSlot Timeslot { get; set; }
        
    }
}
