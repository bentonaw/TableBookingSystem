using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TableBookingSystem.Models.DTOs
{
	// Simplified CreateReservationDTO for easier use with frontend UI
	public class CreateReservationDTO
	{
        [Required]
        public int CustomerId { get; set; } 
		[Required]
		public int TimeSlotId { get; set; }
        [Required]
        public int TableId { get; set; }

        [Required]
        public int NrOfSeats { get; set; }
		[DataType(DataType.Date)]
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
    }
}
