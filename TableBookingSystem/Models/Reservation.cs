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
        [Required]
        public int NrOfSeats { get; set; }
    }
}
