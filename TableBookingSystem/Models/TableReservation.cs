using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableBookingSystem.Models
{
	public class TableReservation
	{
        [Key]
        public int TableReservationId { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }
    }
}
