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

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual TimeSlot Timeslot { get; set; }
        public virtual Table Table { get; set; }

    }
}
